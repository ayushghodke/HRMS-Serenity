using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Communication.Pages;

[PageAuthorize(typeof(SocialPostRow))]
public class SocialCalendarPage : Controller
{
    [Route("Communication/SocialCalendar")]
    public ActionResult Index()
    {
        return this.GridPage("@/Communication/SocialCalendar/SocialCalendarPage",
            "Content Calendar");
    }
}
