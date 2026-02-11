using Serenity.ComponentModel;

namespace HRMS.Communication.Forms;

[FormScript("Communication.Notice")]
[BasedOnRow(typeof(NoticeRow), CheckNames = true)]
public class NoticeForm
{
    public string Title { get; set; }
    [TextAreaEditor(Rows = 8)]
    public string Description { get; set; }
    public NoticePriority Priority { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsActive { get; set; }
}
