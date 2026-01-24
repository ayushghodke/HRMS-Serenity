using Serenity.ComponentModel;

namespace HRMS.HR.Forms;

[FormScript("HR.Department")]
[BasedOnRow(typeof(DepartmentRow), CheckNames = true)]
public class DepartmentForm
{
    public string DepartmentName { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
