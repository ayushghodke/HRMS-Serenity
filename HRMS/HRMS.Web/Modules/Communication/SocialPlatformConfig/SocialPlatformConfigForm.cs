using Serenity.ComponentModel;

namespace HRMS.Communication.Forms;

[FormScript("Communication.SocialPlatformConfig")]
[BasedOnRow(typeof(SocialPlatformConfigRow), CheckNames = true)]
public class SocialPlatformConfigForm
{
    public SocialPlatform Platform { get; set; }
    public string ClientId { get; set; }
    [PasswordEditor]
    public string ClientSecret { get; set; }
    public string RedirectUri { get; set; }
    public bool IsEnabled { get; set; }
}
