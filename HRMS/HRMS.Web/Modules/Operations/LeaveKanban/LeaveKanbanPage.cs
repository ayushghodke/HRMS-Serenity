using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveRow))]
public class LeaveKanbanPage : Controller
{
    [Route("Operations/LeaveKanban")]
    public ActionResult Index()
    {
        return View("~/Modules/Operations/LeaveKanban/LeaveKanbanIndex.cshtml");
    }
}
