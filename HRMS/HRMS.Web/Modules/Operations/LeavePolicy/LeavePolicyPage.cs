using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeavePolicyRow))]
public class LeavePolicyPage : Controller
{
    [Route("Operations/LeavePolicy")]
    public ActionResult Index()
    {
        return this.GridPage<LeavePolicyRow>("@/Operations/LeavePolicy/LeavePolicyPage");
    }
}
