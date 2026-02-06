using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(TaskRow))]
public class TaskKanbanPage : Controller
{
    [Route("Operations/TaskKanban")]
    public ActionResult Index()
    {
        return View("~/Modules/Operations/Task/TaskKanbanIndex.cshtml");
    }
}
