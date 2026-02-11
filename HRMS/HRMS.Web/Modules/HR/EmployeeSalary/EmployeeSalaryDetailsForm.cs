using Serenity.ComponentModel;

namespace HRMS.HR.Forms;

[FormScript("HR.EmployeeSalaryDetails")]
[BasedOnRow(typeof(EmployeeSalaryDetailsRow), CheckNames = true)]
public class EmployeeSalaryDetailsForm
{
    public int ComponentId { get; set; }
    public decimal Amount { get; set; }
}
