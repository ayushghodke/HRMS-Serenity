using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.HR.Columns;

[ColumnsScript("HR.EmployeeSalaryDetails")]
[BasedOnRow(typeof(EmployeeSalaryDetailsRow), CheckNames = true)]
public class EmployeeSalaryDetailsColumns
{
    [EditLink, Width(200)]
    public string ComponentName { get; set; }
    [Width(120), DisplayFormat("#,##0.00"), AlignRight]
    public decimal Amount { get; set; }
    [Width(100)]
    public string ComponentType { get; set; }
}
