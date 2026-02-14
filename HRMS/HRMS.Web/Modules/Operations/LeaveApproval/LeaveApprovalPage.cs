using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveApprovalRow))]
public class LeaveApprovalPage : Controller
{
    [Route("Operations/LeaveApproval")]
    public ActionResult Index()
    {
        return this.GridPage<LeaveApprovalRow>("@/Operations/LeaveApproval/LeaveApprovalPage");
    }
}
