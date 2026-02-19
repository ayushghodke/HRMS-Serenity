using Serenity.ComponentModel;

namespace HRMS.Communication.Columns;

[ColumnsScript("Communication.SocialAccount")]
[BasedOnRow(typeof(SocialAccountRow), CheckNames = true)]
public class SocialAccountColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int SocialAccountId { get; set; }
    public SocialPlatform Platform { get; set; }
    [EditLink]
    public string AccountName { get; set; }
    public string ProfileUrl { get; set; }
    public DateTime ConnectedDate { get; set; }
    public bool IsActive { get; set; }
}
