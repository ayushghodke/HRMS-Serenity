using Serenity.ComponentModel;

namespace HRMS.Communication.Forms;

[FormScript("Communication.SocialAccount")]
[BasedOnRow(typeof(SocialAccountRow), CheckNames = true)]
public class SocialAccountForm
{
    public SocialPlatform Platform { get; set; }
    public string AccountName { get; set; }
    public string ProfileUrl { get; set; }
    public DateTime ConnectedDate { get; set; }
    public bool IsActive { get; set; }
}
