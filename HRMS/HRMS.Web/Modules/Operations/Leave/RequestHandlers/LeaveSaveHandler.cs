using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using MyRow = HRMS.Operations.LeaveRow;

namespace HRMS.Operations;

public interface ILeaveSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class LeaveSaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>, ILeaveSaveHandler
{
    public LeaveSaveHandler(IRequestContext context) : base(context)
    {
    }

    protected override void BeforeSave()
    {
        base.BeforeSave();

        if (!Row.EmployeeId.HasValue)
            throw new ValidationError("EmployeeRequired", "Employee is required.");

        if (!Row.LeaveTypeId.HasValue)
            throw new ValidationError("LeaveTypeRequired", "Leave type is required.");

        if (!Row.StartDate.HasValue || !Row.EndDate.HasValue)
            throw new ValidationError("DateRequired", "Start Date and End Date are required.");

        var employee = Connection.TryById<HR.EmployeeRow>(Row.EmployeeId.Value)
            ?? throw new ValidationError("EmployeeNotFound", "Employee not found.");

        var leaveType = Connection.TryById<LeaveTypeRow>(Row.LeaveTypeId.Value)
            ?? throw new ValidationError("LeaveTypeNotFound", "Leave type not found.");

        if (leaveType.DocumentsRequired == true && string.IsNullOrWhiteSpace(Row.Attachment))
            throw new ValidationError("AttachmentRequired", "Attachment is required for this leave type.");

        if (Row.HalfDaySession.HasValue && leaveType.HalfDayAllowed != true)
            throw new ValidationError("HalfDayNotAllowed", "Half day is not allowed for this leave type.");

        var startDate = Row.StartDate.Value.Date;
        var endDate = Row.EndDate.Value.Date;

        if (endDate < startDate)
            throw new ValidationError("InvalidDateRange", "End Date must be on or after Start Date.");

        EnsureNoOverlap(Row.EmployeeId.Value, startDate, endDate, Row.LeaveId);

        var applicableHolidays = GetApplicableHolidayDates(startDate, endDate);
        var leaveDays = BuildLeaveDaySlices(
            startDate,
            endDate,
            Row.HalfDaySession.HasValue,
            leaveType.SandwichRuleApplicable == true,
            applicableHolidays);

        var totalDays = leaveDays.Sum(x => x.Days);
        if (totalDays <= 0m)
            throw new ValidationError("InvalidTotalDays", "Total days must be greater than zero.");

        if (leaveType.MaxLeavePerRequest.GetValueOrDefault() > 0m && totalDays > leaveType.MaxLeavePerRequest.Value)
            throw new ValidationError("MaxLeaveExceeded", $"This leave type allows a maximum of {leaveType.MaxLeavePerRequest.Value:0.##} days per request.");

        ValidateServiceAndProbationRules(employee, leaveType, totalDays);

        Row.TotalDays = (double)totalDays;

        if (IsCreate)
        {
            Row.CreatedDate = DateTime.Now;
            Row.ApplicationDate = DateTime.Now;
            Row.LeaveApplicationNo = "LV-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Row.Status = LeaveStatus.Pending;
            Row.HrApprovalStatus = Operations.HrApprovalStatus.Pending;
            Row.FinalStatus = Operations.LeaveFinalStatus.Pending;
        }

        if (!Row.ReportingManagerId.HasValue)
            Row.ReportingManagerId = employee.ManagerId;

        var monthlyQuota = (decimal)Math.Max(0, employee.PaidLeavesPerMonth ?? 2);
        var consumedPaidByMonth = GetApprovedPaidUsageByMonth(Row.EmployeeId.Value, Row.LeaveId);
        var requestDaysByMonth = leaveDays
            .GroupBy(x => GetMonthKey(x.Date))
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Days), StringComparer.Ordinal);

        decimal paidDays = 0m;
        decimal unpaidDays = 0m;

        if (leaveType.LeaveCategory == LeaveCategory.Unpaid)
        {
            paidDays = 0m;
            unpaidDays = totalDays;
            Row.PaidDays = paidDays;
            Row.UnpaidDays = unpaidDays;
            Row.LeaveType = LeaveType.Unpaid;
            return;
        }

        foreach (var monthItem in requestDaysByMonth)
        {
            consumedPaidByMonth.TryGetValue(monthItem.Key, out var alreadyConsumed);
            var availablePaid = Math.Max(0m, monthlyQuota - alreadyConsumed);
            var paidForMonth = Math.Min(monthItem.Value, availablePaid);
            var unpaidForMonth = monthItem.Value - paidForMonth;

            paidDays += paidForMonth;
            unpaidDays += unpaidForMonth;
        }

        Row.PaidDays = paidDays;
        Row.UnpaidDays = unpaidDays;
        Row.LeaveType = unpaidDays > 0 ? LeaveType.Unpaid : LeaveType.PaidLeave;
    }

    private void ValidateServiceAndProbationRules(HR.EmployeeRow employee, LeaveTypeRow leaveType, decimal totalDays)
    {
        var joiningDate = employee.JoiningDate?.Date;
        var tenureMonths = joiningDate.HasValue ? Math.Max(0, (DateTime.Today.Year - joiningDate.Value.Year) * 12 + DateTime.Today.Month - joiningDate.Value.Month) : int.MaxValue;

        if (leaveType.MinimumServiceRequiredMonths.GetValueOrDefault() > 0 && tenureMonths < leaveType.MinimumServiceRequiredMonths.Value)
            throw new ValidationError("InsufficientService", $"Minimum service requirement is {leaveType.MinimumServiceRequiredMonths.Value} month(s) for this leave type.");

        if (leaveType.ProbationApplicable == false && tenureMonths < 6)
            throw new ValidationError("ProbationRestriction", "This leave type is not allowed during probation period.");

        var profile = Connection.TryFirst<EmployeeLeaveProfileRow>(
            EmployeeLeaveProfileRow.Fields.EmployeeId == employee.EmployeeId.Value &
            EmployeeLeaveProfileRow.Fields.LeaveTypeId == leaveType.LeaveTypeId.Value);

        if (profile?.LeavePolicyId is not int policyId)
            return;

        var policy = Connection.TryById<LeavePolicyRow>(policyId);
        if (policy == null)
            return;

        if (policy.MaxConsecutiveLeavesAllowed.GetValueOrDefault() > 0 && totalDays > policy.MaxConsecutiveLeavesAllowed.Value)
            throw new ValidationError("ConsecutiveLeaveExceeded", $"Policy allows maximum {policy.MaxConsecutiveLeavesAllowed.Value} consecutive leave day(s).");

        if (policy.ProbationLeaveAllowed == false && tenureMonths < 6)
            throw new ValidationError("ProbationPolicyRestriction", "Current leave policy does not allow leave during probation period.");
    }

    private void EnsureNoOverlap(int employeeId, DateTime startDate, DateTime endDate, int? excludeLeaveId)
    {
        var fld = MyRow.Fields;
        var existingLeaves = Connection.List<MyRow>(fld.EmployeeId == employeeId);

        foreach (var leave in existingLeaves)
        {
            if (excludeLeaveId.HasValue && leave.LeaveId == excludeLeaveId.Value)
                continue;

            if (!leave.StartDate.HasValue || !leave.EndDate.HasValue)
                continue;

            var isRejectedOrCancelled = leave.FinalStatus == LeaveFinalStatus.Rejected || leave.FinalStatus == LeaveFinalStatus.Cancelled;
            if (isRejectedOrCancelled)
                continue;

            var hasOverlap = leave.StartDate.Value.Date <= endDate && leave.EndDate.Value.Date >= startDate;
            if (hasOverlap)
                throw new ValidationError("LeaveOverlap", "The selected date range overlaps with an existing leave request.");
        }
    }

    private HashSet<DateTime> GetApplicableHolidayDates(DateTime startDate, DateTime endDate)
    {
        var fld = HolidayRow.Fields;
        var holidays = Connection.List<HolidayRow>(
            fld.HolidayDate >= startDate &
            fld.HolidayDate <= endDate &
            fld.IsOptionalHoliday == 0);

        var set = new HashSet<DateTime>();
        foreach (var holiday in holidays)
        {
            if (holiday.HolidayDate.HasValue)
                set.Add(holiday.HolidayDate.Value.Date);
        }

        return set;
    }

    private static List<LeaveDaySlice> BuildLeaveDaySlices(
        DateTime startDate,
        DateTime endDate,
        bool isHalfDay,
        bool sandwichRuleApplicable,
        HashSet<DateTime> holidayDates)
    {
        var slices = new List<LeaveDaySlice>();

        for (var day = startDate; day <= endDate; day = day.AddDays(1))
        {
            var isWeekend = day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday;
            var isHoliday = holidayDates.Contains(day.Date);
            var countAsLeaveDay = sandwichRuleApplicable || (!isWeekend && !isHoliday);

            if (countAsLeaveDay)
                slices.Add(new LeaveDaySlice(day.Date, 1m));
        }

        if (isHalfDay)
        {
            if (slices.Count == 0)
                throw new ValidationError("InvalidHalfDay", "Half-day leave cannot be applied on non-working days.");

            var first = slices[0];
            slices[0] = new LeaveDaySlice(first.Date, 0.5m);
        }

        return slices;
    }

    private Dictionary<string, decimal> GetApprovedPaidUsageByMonth(int employeeId, int? excludeLeaveId)
    {
        var fld = MyRow.Fields;
        var approvedLeaves = Connection.List<MyRow>(
            fld.EmployeeId == employeeId &
            fld.FinalStatus == (int)LeaveFinalStatus.Approved);

        var usage = new Dictionary<string, decimal>(StringComparer.Ordinal);

        foreach (var leave in approvedLeaves)
        {
            if (excludeLeaveId.HasValue && leave.LeaveId == excludeLeaveId.Value)
                continue;

            if (!leave.StartDate.HasValue || !leave.EndDate.HasValue)
                continue;

            var total = (decimal)(leave.TotalDays ?? 0);
            if (total <= 0)
                continue;

            var paid = leave.PaidDays ?? (leave.LeaveType == LeaveType.PaidLeave ? total : 0m);
            if (paid <= 0)
                continue;

            AddPaidUsageByMonth(usage, leave.StartDate.Value.Date, leave.EndDate.Value.Date, paid);
        }

        return usage;
    }

    private static void AddPaidUsageByMonth(Dictionary<string, decimal> usage, DateTime startDate, DateTime endDate, decimal paidDays)
    {
        var remainingPaid = paidDays;

        for (var day = startDate; day <= endDate && remainingPaid > 0m; day = day.AddDays(1))
        {
            var key = GetMonthKey(day);
            var allocate = Math.Min(1m, remainingPaid);
            usage.TryGetValue(key, out var current);
            usage[key] = current + allocate;
            remainingPaid -= allocate;
        }
    }

    private static string GetMonthKey(DateTime date)
    {
        return $"{date.Year:D4}-{date.Month:D2}";
    }

    private sealed class LeaveDaySlice
    {
        public LeaveDaySlice(DateTime date, decimal days)
        {
            Date = date;
            Days = days;
        }

        public DateTime Date { get; }
        public decimal Days { get; }
    }
}
