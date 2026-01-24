using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveRow))]
public class LeavePage : Controller
{
    [Route("Operations/Leave")]
    public ActionResult Index()
    {
        return this.GridPage<LeaveRow>("@/Operations/Leave/LeavePage");
    }
}
