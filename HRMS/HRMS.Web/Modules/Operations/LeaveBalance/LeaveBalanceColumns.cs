using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.LeaveBalance")]
[BasedOnRow(typeof(LeaveBalanceRow), CheckNames = true)]
public class LeaveBalanceColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int LeaveBalanceId { get; set; }
    [EditLink]
    public string EmployeeFullName { get; set; }
    [Width(100), QuickFilter]
    public LeaveType LeaveType { get; set; }
    [Width(80)]
    public int Year { get; set; }
    [Width(80), AlignRight]
    public decimal Allocated { get; set; }
    [Width(80), AlignRight]
    public decimal Used { get; set; }
    [Width(80), AlignRight]
    public decimal Balance { get; set; }
}
