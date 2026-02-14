using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using MyRow = HRMS.Operations.LeaveRow;

namespace HRMS.Operations;

public interface ILeaveSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> {}

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

        var startDate = Row.StartDate.Value.Date;
        var endDate = Row.EndDate.Value.Date;

        if (endDate < startDate)
            throw new ValidationError("InvalidDateRange", "End Date must be on or after Start Date.");

        var totalDays = (decimal)(endDate - startDate).TotalDays + 1m;
        if (Row.HalfDaySession.HasValue)
            totalDays -= 0.5m;

        if (totalDays <= 0)
            throw new ValidationError("InvalidTotalDays", "Total days must be greater than zero.");

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

        var employee = Connection.TryById<HR.EmployeeRow>(Row.EmployeeId.Value)
            ?? throw new ValidationError("EmployeeNotFound", "Employee not found.");

        if (!Row.ReportingManagerId.HasValue)
            Row.ReportingManagerId = employee.ManagerId;

        var leaveType = Connection.TryById<LeaveTypeRow>(Row.LeaveTypeId.Value)
            ?? throw new ValidationError("LeaveTypeNotFound", "Leave type not found.");

        if (leaveType.DocumentsRequired == true && string.IsNullOrWhiteSpace(Row.Attachment))
            throw new ValidationError("AttachmentRequired", "Attachment is required for this leave type.");

        var monthlyQuota = (decimal)Math.Max(0, employee.PaidLeavesPerMonth ?? 2);
        var consumedPaidByMonth = GetApprovedPaidUsageByMonth(Row.EmployeeId.Value, Row.LeaveId);

        var requestDaysByMonth = new Dictionary<string, decimal>(StringComparer.Ordinal);
        for (var day = startDate; day <= endDate; day = day.AddDays(1))
        {
            var key = GetMonthKey(day);
            requestDaysByMonth.TryGetValue(key, out var current);
            requestDaysByMonth[key] = current + 1m;
        }

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

    private Dictionary<string, decimal> GetApprovedPaidUsageByMonth(int employeeId, int? excludeLeaveId)
    {
        var fld = MyRow.Fields;
        var approvedLeaves = Connection.List<MyRow>(
            fld.EmployeeId == employeeId & fld.Status == (int)LeaveStatus.Approved);

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
}
