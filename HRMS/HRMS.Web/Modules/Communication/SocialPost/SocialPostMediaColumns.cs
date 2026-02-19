using Serenity.ComponentModel;

namespace HRMS.Communication.Columns;

[ColumnsScript("Communication.SocialPostMedia")]
[BasedOnRow(typeof(SocialPostMediaRow), CheckNames = true)]
public class SocialPostMediaColumns
{
    [EditLink]
    public string FileName { get; set; }
    public SocialMediaType MediaType { get; set; }
    public int DisplayOrder { get; set; }
}
