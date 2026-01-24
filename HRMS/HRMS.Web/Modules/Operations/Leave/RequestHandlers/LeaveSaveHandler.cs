using Serenity.Data;
using Serenity.Services;
using System;
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

        if (IsCreate)
        {
            Row.CreatedDate = DateTime.Now;
        }
    }

    protected override void AfterSave()
    {
        base.AfterSave();

        // Update leave balance when a new leave is created
        if (IsCreate && Row.EmployeeId.HasValue && Row.LeaveType.HasValue && Row.TotalDays.HasValue)
        {
            UpdateLeaveBalance(Row.EmployeeId.Value, Row.LeaveType.Value, (decimal)Row.TotalDays.Value);
        }
    }

    private void UpdateLeaveBalance(int employeeId, LeaveType leaveType, decimal days)
    {
        var currentYear = DateTime.Now.Year;
        var fld = LeaveBalanceRow.Fields;

        // Find the existing balance record
        var balance = Connection.TryFirst<LeaveBalanceRow>(
            fld.EmployeeId == employeeId & 
            fld.LeaveType == (int)leaveType & 
            fld.Year == currentYear);

        if (balance != null)
        {
            // Update the Used field
            var newUsed = (balance.Used ?? 0) + days;
            Connection.UpdateById(new LeaveBalanceRow
            {
                LeaveBalanceId = balance.LeaveBalanceId,
                Used = newUsed
            });
        }
        else
        {
            // Create new balance record if doesn't exist
            var defaultAllocated = leaveType switch
            {
                LeaveType.Casual => 12m,
                LeaveType.Sick => 10m,
                LeaveType.Earned => 15m,
                LeaveType.Unpaid => 0m,
                _ => 0m
            };

            Connection.Insert(new LeaveBalanceRow
            {
                EmployeeId = employeeId,
                LeaveType = leaveType,
                Year = currentYear,
                Allocated = defaultAllocated,
                Used = days
            });
        }
    }
}

