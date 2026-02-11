using Serenity.ComponentModel;
using System;

namespace HRMS.Operations.Forms;

[FormScript("Operations.SalaryGrade")]
[BasedOnRow(typeof(SalaryGradeRow), CheckNames = true)]
public class SalaryGradeForm
{
    public string GradeName { get; set; }
    public string GradeCode { get; set; }
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
