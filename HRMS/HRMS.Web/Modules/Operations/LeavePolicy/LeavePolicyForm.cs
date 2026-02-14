using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.LeavePolicy")]
[BasedOnRow(typeof(LeavePolicyRow), CheckNames = true)]
public class LeavePolicyForm
{
    public string PolicyName { get; set; }
    public DateTime ApplicableFromDate { get; set; }
    public string Branch { get; set; }
    public int DepartmentId { get; set; }
    public int MaxConsecutiveLeavesAllowed { get; set; }
    public bool NoticePeriodLeaveAllowed { get; set; }
    public bool ProbationLeaveAllowed { get; set; }
    public ApprovalLevelMode ApprovalLevels { get; set; }
    public bool HROverridePermission { get; set; }
    public int PayrollCutoffDay { get; set; }
    public RecordStatus Status { get; set; }
}
