using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.HR.Columns;

[ColumnsScript("HR.Designation")]
[BasedOnRow(typeof(DesignationRow), CheckNames = true)]
public class DesignationColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int DesignationId { get; set; }
    [EditLink]
    public string DesignationName { get; set; }
    public int Level { get; set; }
    [Width(100), AlignCenter]
    public bool IsActive { get; set; }
}
