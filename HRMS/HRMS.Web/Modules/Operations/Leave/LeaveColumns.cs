using Serenity.ComponentModel;
using System.ComponentModel;
using HRMS.HR;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.Leave")]
[BasedOnRow(typeof(LeaveRow), CheckNames = true)]
public class LeaveColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int LeaveId { get; set; }
    [EditLink]
    public string EmployeeFullName { get; set; }
    [Width(100), QuickFilter]
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double TotalDays { get; set; }
    public string Reason { get; set; }
    [Width(100), QuickFilter, AlignCenter]
    public LeaveStatus Status { get; set; }
    public string ApprovedByUsername { get; set; }
}
