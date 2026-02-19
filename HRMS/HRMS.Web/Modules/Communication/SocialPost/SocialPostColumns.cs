using Serenity.ComponentModel;

namespace HRMS.Communication.Columns;

[ColumnsScript("Communication.SocialPost")]
[BasedOnRow(typeof(SocialPostRow), CheckNames = true)]
public class SocialPostColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int SocialPostId { get; set; }
    public string SocialAccountName { get; set; }
    public SocialPlatform SocialAccountPlatform { get; set; }
    [EditLink]
    public string Title { get; set; }
    public SocialPostType PostType { get; set; }
    public SocialPostStatus Status { get; set; }
    public DateTime ScheduledDate { get; set; }
    public DateTime PublishedDate { get; set; }
}
