using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveRow))]
public class LeaveReportsPage : Controller
{
    [Route("Operations/LeaveReports")]
    public ActionResult Index()
    {
        return View("~/Modules/Operations/LeaveReports/LeaveReportsIndex.cshtml");
    }
}
