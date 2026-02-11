using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.HR.Columns;

[ColumnsScript("HR.EmployeeSalary")]
[BasedOnRow(typeof(EmployeeSalaryRow), CheckNames = true)]
public class EmployeeSalaryColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int EmployeeSalaryId { get; set; }
    [EditLink, Width(200)]
    public string EmployeeName { get; set; }
    [Width(150)]
    public string GradeName { get; set; }
    [Width(100), AlignRight]
    public DateTime EffectiveDate { get; set; }
    [Width(120), DisplayFormat("#,##0.00"), AlignRight]
    public decimal BasicSalary { get; set; }
    [Width(120), DisplayFormat("#,##0.00"), AlignRight]
    public decimal GrossSalary { get; set; }
    [Width(80)]
    public bool IsActive { get; set; }
}
