using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveTypeRow))]
public class LeaveTypePage : Controller
{
    [Route("Operations/LeaveType")]
    public ActionResult Index()
    {
        return this.GridPage<LeaveTypeRow>("@/Operations/LeaveType/LeaveTypePage");
    }
}
