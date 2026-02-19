using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Communication.Pages;

[PageAuthorize(typeof(SocialPlatformConfigRow))]
public class SocialPlatformConfigPage : Controller
{
    [Route("Communication/SocialPlatformConfig")]
    public ActionResult Index()
    {
        return this.GridPage("@/Communication/SocialPlatformConfig/SocialPlatformConfigPage",
            SocialPlatformConfigRow.Fields.PageTitle());
    }
}
