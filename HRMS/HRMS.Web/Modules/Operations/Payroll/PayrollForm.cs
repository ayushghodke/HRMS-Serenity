using Serenity.ComponentModel;
using HRMS.Operations;

namespace HRMS.Operations.Forms;

[FormScript("Operations.Payroll")]
[BasedOnRow(typeof(PayrollRow), CheckNames = true)]
public class PayrollForm
{
    public int EmployeeId { get; set; }
    [HalfWidth]
    public Month Month { get; set; }
    [HalfWidth]
    public int Year { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal Allowances { get; set; }
    public decimal Deductions { get; set; }
    public decimal NetSalary { get; set; }
}
