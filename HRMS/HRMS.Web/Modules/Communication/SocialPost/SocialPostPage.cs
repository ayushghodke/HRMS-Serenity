using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Communication.Pages;

[PageAuthorize(typeof(SocialPostRow))]
public class SocialPostPage : Controller
{
    [Route("Communication/SocialPost")]
    public ActionResult Index()
    {
        return this.GridPage("@/Communication/SocialPost/SocialPostPage",
            SocialPostRow.Fields.PageTitle());
    }
}
