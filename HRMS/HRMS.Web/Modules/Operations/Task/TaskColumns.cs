using Serenity.ComponentModel;
using System.ComponentModel;
using HRMS.Operations;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.Task")]
[BasedOnRow(typeof(TaskRow), CheckNames = true)]
public class TaskColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int TaskId { get; set; }
    [EditLink]
    public string Title { get; set; }
    public string AssignedToFullName { get; set; }
    public string AssignedByUsername { get; set; }
    public DateTime DueDate { get; set; }
    [Width(100), QuickFilter, AlignCenter]
    public TaskStatus Status { get; set; }
}
