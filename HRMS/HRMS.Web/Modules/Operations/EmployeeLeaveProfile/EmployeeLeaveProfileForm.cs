using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.EmployeeLeaveProfile")]
[BasedOnRow(typeof(EmployeeLeaveProfileRow), CheckNames = true)]
public class EmployeeLeaveProfileForm
{
    public int EmployeeId { get; set; }
    public int LeavePolicyId { get; set; }
    public int LeaveTypeId { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal AccruedLeave { get; set; }
    public decimal UsedLeave { get; set; }
    public decimal PendingLeave { get; set; }
    public decimal CarryForwardLeave { get; set; }
    public decimal LOPDays { get; set; }
}
