using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.LeaveApproval")]
[BasedOnRow(typeof(LeaveApprovalRow), CheckNames = true)]
public class LeaveApprovalColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int ApprovalId { get; set; }
    [EditLink]
    public string LeaveApplicationNo { get; set; }
    public string ApproverUsername { get; set; }
    public int ApprovalLevel { get; set; }
    public DateTime ApprovalDate { get; set; }
    public LeaveStatus Status { get; set; }
    public string Remarks { get; set; }
}
