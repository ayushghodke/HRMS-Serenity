using Serenity.ComponentModel;
using HRMS.Operations;

namespace HRMS.Operations.Forms;

[FormScript("Operations.Task")]
[BasedOnRow(typeof(TaskRow), CheckNames = true)]
public class TaskForm
{
    public string Title { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Description { get; set; }
    public int AssignedTo { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }
    public int AssignedBy { get; set; }
}
