using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Recruitment.Pages;

[PageAuthorize(typeof(InterviewsRow))]
public class InterviewCalendarPage : Controller
{
    [Route("Recruitment/InterviewCalendar")]
    public ActionResult Index()
    {
        return View("~/Modules/Recruitment/InterviewCalendar/InterviewCalendarIndex.cshtml");
    }
}
