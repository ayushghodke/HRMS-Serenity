using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Communication.Pages;

[PageAuthorize(typeof(SocialAccountRow))]
public class SocialAccountPage : Controller
{
    [Route("Communication/SocialAccount")]
    public ActionResult Index()
    {
        return this.GridPage("@/Communication/SocialAccount/SocialAccountPage",
            SocialAccountRow.Fields.PageTitle());
    }
}
