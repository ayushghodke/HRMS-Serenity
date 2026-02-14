using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.LeaveApproval")]
[BasedOnRow(typeof(LeaveApprovalRow), CheckNames = true)]
public class LeaveApprovalForm
{
    public int LeaveId { get; set; }
    public int ApproverId { get; set; }
    public int ApprovalLevel { get; set; }
    public DateTime ApprovalDate { get; set; }
    public LeaveStatus Status { get; set; }
    [TextAreaEditor(Rows = 2)]
    public string Remarks { get; set; }
    public bool EscalationTrigger { get; set; }
    public int EscalationTo { get; set; }
}
