using Serenity.ComponentModel;

namespace HRMS.Communication.Forms;

[FormScript("Communication.SocialPostMedia")]
[BasedOnRow(typeof(SocialPostMediaRow), CheckNames = true)]
public class SocialPostMediaForm
{
    public string FileName { get; set; }
    public SocialMediaType MediaType { get; set; }
    public int DisplayOrder { get; set; }
}
