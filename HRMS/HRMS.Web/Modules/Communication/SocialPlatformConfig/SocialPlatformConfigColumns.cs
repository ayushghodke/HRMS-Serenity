using Serenity.ComponentModel;

namespace HRMS.Communication.Columns;

[ColumnsScript("Communication.SocialPlatformConfig")]
[BasedOnRow(typeof(SocialPlatformConfigRow), CheckNames = true)]
public class SocialPlatformConfigColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int SocialPlatformConfigId { get; set; }
    [EditLink]
    public SocialPlatform Platform { get; set; }
    public string ClientId { get; set; }
    public string RedirectUri { get; set; }
    public bool IsEnabled { get; set; }
}
