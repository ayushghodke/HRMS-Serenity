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
            
            // Validate leave balance
            if (Row.EmployeeId.HasValue && Row.LeaveType.HasValue && Row.TotalDays.HasValue)
            {
                // Only validate for Paid Leave
                if (Row.LeaveType.Value == LeaveType.PaidLeave)
                {
                    var currentYear = DateTime.Now.Year;
                    var fld = LeaveBalanceRow.Fields;
                    
                    var balance = Connection.TryFirst<LeaveBalanceRow>(
                        fld.EmployeeId == Row.EmployeeId.Value & 
                        fld.LeaveType == (int)Row.LeaveType.Value & 
                        fld.Year == currentYear);
                    
                    // Calculate accrued leaves based on months worked
                    var employeeFld = HR.EmployeeRow.Fields;
                    var employee = Connection.TryById<HR.EmployeeRow>(Row.EmployeeId.Value);
                    
                    if (employee?.JoiningDate != null)
                    {
                        var monthsWorked = CalculateMonthsWorked(employee.JoiningDate.Value);
                        var accruedLeaves = monthsWorked * 3m; // 3 leaves per month
                        var usedLeaves = balance?.Used ?? 0m;
                        var availableBalance = accruedLeaves - usedLeaves;
                        
                        if (availableBalance < (decimal)Row.TotalDays.Value)
                        {
                            throw new ValidationError("InsufficientBalance", 
                                $"Insufficient leave balance. You have {availableBalance} paid leaves available (accrued: {accruedLeaves}, used: {usedLeaves}).");
                        }
                    }
                }
                // Unpaid leave - no validation needed
            }
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
            // For Paid Leave: 3 leaves/month × 12 months = 36 leaves/year
            var defaultAllocated = leaveType == LeaveType.PaidLeave ? 36m : 0m;

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
    
    private int CalculateMonthsWorked(DateTime joinDate)
    {
        var today = DateTime.Now;
        var months = ((today.Year - joinDate.Year) * 12) + today.Month - joinDate.Month;
        
        // Add 1 if the employee joined before the current day of the month
        if (today.Day >= joinDate.Day)
            months++;
            
        return Math.Max(0, months);
    }
}
