using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.HR.Columns;

[ColumnsScript("HR.Department")]
[BasedOnRow(typeof(DepartmentRow), CheckNames = true)]
public class DepartmentColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int DepartmentId { get; set; }
    [EditLink]
    public string DepartmentName { get; set; }
    public string Description { get; set; }
    [Width(100), AlignCenter]
    public bool IsActive { get; set; }
}
