using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.LeavePolicy")]
[BasedOnRow(typeof(LeavePolicyRow), CheckNames = true)]
public class LeavePolicyColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int LeavePolicyId { get; set; }
    [EditLink]
    public string PolicyName { get; set; }
    public DateTime ApplicableFromDate { get; set; }
    public string Branch { get; set; }
    public string DepartmentName { get; set; }
    public int MaxConsecutiveLeavesAllowed { get; set; }
    public ApprovalLevelMode ApprovalLevels { get; set; }
    public int PayrollCutoffDay { get; set; }
    public RecordStatus Status { get; set; }
}
