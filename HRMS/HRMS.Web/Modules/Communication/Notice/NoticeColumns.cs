using Serenity.ComponentModel;

namespace HRMS.Communication.Columns;

[ColumnsScript("Communication.Notice")]
[BasedOnRow(typeof(NoticeRow), CheckNames = true)]
public class NoticeColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int NoticeId { get; set; }
    [EditLink]
    public string Title { get; set; }
    public NoticePriority Priority { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsActive { get; set; }
}
