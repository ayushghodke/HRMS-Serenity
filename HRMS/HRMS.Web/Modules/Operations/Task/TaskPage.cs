using Microsoft.AspNetCore.Mvc;
using Serenity.Web;
using HRMS.Operations;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(TaskRow))]
public class TaskPage : Controller
{
    [Route("Operations/Task")]
    public ActionResult Index()
    {
        return this.GridPage<TaskRow>("@/Operations/Task/TaskPage");
    }
}
