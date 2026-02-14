using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.LeaveBalance")]
[BasedOnRow(typeof(LeaveBalanceRow), CheckNames = true)]
public class LeaveBalanceColumns
{
    [EditLink, Width(200)]
    public string EmployeeFullName { get; set; }
    public LeaveType LeaveType { get; set; }
    public int EmployeePaidLeavesPerMonth { get; set; }
    public DateTime EmployeeJoinDate { get; set; }
    public int MonthsWorked { get; set; }
    public int AccruedLeaves { get; set; }
    public decimal LeavesThisMonth { get; set; }
    public decimal LeavesPreviousMonths { get; set; }
}
