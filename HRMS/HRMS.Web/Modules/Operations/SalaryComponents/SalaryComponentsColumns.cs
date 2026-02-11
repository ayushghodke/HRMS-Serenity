using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.SalaryComponents")]
[BasedOnRow(typeof(SalaryComponentsRow), CheckNames = true)]
public class SalaryComponentsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int ComponentId { get; set; }
    [EditLink, Width(200)]
    public string ComponentName { get; set; }
    [Width(120)]
    public SalaryComponentType ComponentType { get; set; }
    [Width(120)]
    public SalaryCalculationType CalculationType { get; set; }
    [Width(150)]
    public string PercentageOfComponentName { get; set; }
    [Width(80)]
    public bool IsStatutory { get; set; }
    [Width(80)]
    public bool IsTaxable { get; set; }
    [Width(80)]
    public bool IsActive { get; set; }
    [Width(100)]
    public int DisplayOrder { get; set; }
}
