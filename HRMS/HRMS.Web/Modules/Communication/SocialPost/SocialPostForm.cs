using Serenity.ComponentModel;

namespace HRMS.Communication.Forms;

[FormScript("Communication.SocialPost")]
[BasedOnRow(typeof(SocialPostRow), CheckNames = true)]
public class SocialPostForm
{
    public int SocialAccountId { get; set; }
    public string Title { get; set; }
    [TextAreaEditor(Rows = 6)]
    public string Content { get; set; }
    public SocialPostType PostType { get; set; }
    public SocialPostStatus Status { get; set; }
    public DateTime ScheduledDate { get; set; }
    public DateTime PublishedDate { get; set; }
    [SocialPostMediaEditorAttribute]
    public List<SocialPostMediaRow> MediaList { get; set; }
}

public class SocialPostMediaEditorAttribute : CustomEditorAttribute
{
    public const string Key = "HRMS.Communication.SocialPostMediaEditor";

    public SocialPostMediaEditorAttribute()
        : base(Key)
    {
    }
}
