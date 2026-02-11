using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.SalaryGrade")]
[BasedOnRow(typeof(SalaryGradeRow), CheckNames = true)]
public class SalaryGradeColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int GradeId { get; set; }
    [EditLink, Width(200)]
    public string GradeName { get; set; }
    [Width(100)]
    public string GradeCode { get; set; }
    [Width(120), DisplayFormat("#,##0.00"), AlignRight]
    public decimal MinSalary { get; set; }
    [Width(120), DisplayFormat("#,##0.00"), AlignRight]
    public decimal MaxSalary { get; set; }
    [Width(80)]
    public bool IsActive { get; set; }
}
