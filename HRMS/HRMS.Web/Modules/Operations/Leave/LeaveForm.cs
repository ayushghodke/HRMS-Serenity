using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.Leave")]
[BasedOnRow(typeof(LeaveRow), CheckNames = true)]
public class LeaveForm
{
    public int EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    [HalfWidth]
    public DateTime StartDate { get; set; }
    [HalfWidth]
    public DateTime EndDate { get; set; }
    public double TotalDays { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Reason { get; set; }
    public LeaveStatus Status { get; set; }
    public int ApprovedBy { get; set; }
}
