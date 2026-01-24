using Serenity.ComponentModel;
using System.ComponentModel;
using HRMS.Operations;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.Payroll")]
[BasedOnRow(typeof(PayrollRow), CheckNames = true)]
public class PayrollColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int PayrollId { get; set; }
    [EditLink]
    public string EmployeeFullName { get; set; }
    [Width(100), QuickFilter]
    public Month Month { get; set; }
    [Width(80), QuickFilter]
    public int Year { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal Allowances { get; set; }
    public decimal Deductions { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime GeneratedDate { get; set; }
}
