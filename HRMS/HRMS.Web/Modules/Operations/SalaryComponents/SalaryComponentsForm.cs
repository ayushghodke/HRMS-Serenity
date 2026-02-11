using Serenity.ComponentModel;
using System;

namespace HRMS.Operations.Forms;

[FormScript("Operations.SalaryComponents")]
[BasedOnRow(typeof(SalaryComponentsRow), CheckNames = true)]
public class SalaryComponentsForm
{
    public string ComponentName { get; set; }
    public SalaryComponentType ComponentType { get; set; }
    public SalaryCalculationType CalculationType { get; set; }
    public int PercentageOf { get; set; }
    public bool IsStatutory { get; set; }
    public bool IsTaxable { get; set; }
    public int DisplayOrder { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
