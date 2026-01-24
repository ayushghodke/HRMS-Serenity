using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveRow))]
public class LeaveCalendarPage : Controller
{
    [Route("Operations/LeaveCalendar")]
    public ActionResult Index()
    {
        return View(MVC.Views.Operations.LeaveCalendar.LeaveCalendarIndex);
    }
}
