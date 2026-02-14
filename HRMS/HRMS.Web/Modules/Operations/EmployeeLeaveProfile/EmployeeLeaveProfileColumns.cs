using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.EmployeeLeaveProfile")]
[BasedOnRow(typeof(EmployeeLeaveProfileRow), CheckNames = true)]
public class EmployeeLeaveProfileColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int EmployeeLeaveProfileId { get; set; }
    [EditLink]
    public string EmployeeFullName { get; set; }
    public string DepartmentName { get; set; }
    public string DesignationName { get; set; }
    public string LeavePolicyName { get; set; }
    public string LeaveTypeName { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal AccruedLeave { get; set; }
    public decimal UsedLeave { get; set; }
    public decimal PendingLeave { get; set; }
    public decimal CarryForwardLeave { get; set; }
    public decimal LOPDays { get; set; }
    public DateTime LastUpdatedDate { get; set; }
}
