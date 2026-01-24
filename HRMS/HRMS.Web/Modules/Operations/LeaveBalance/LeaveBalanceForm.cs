using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.LeaveBalance")]
[BasedOnRow(typeof(LeaveBalanceRow), CheckNames = true)]
public class LeaveBalanceForm
{
    public int EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public int Year { get; set; }
    public decimal Allocated { get; set; }
    public decimal Used { get; set; }
}
