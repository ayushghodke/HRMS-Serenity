using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveRow))]
public class LeaveDashboardPage : Controller
{
    [Route("Operations/LeaveDashboard")]
    public ActionResult Index()
    {
        return View("~/Modules/Operations/LeaveDashboard/LeaveDashboardIndex.cshtml");
    }
}
