using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(LeaveBalanceRow))]
public class LeaveBalancePage : Controller
{
    [Route("Operations/LeaveBalance")]
    public ActionResult Index()
    {
        return this.GridPage("@/Operations/LeaveBalance/LeaveBalancePage",
            LeaveBalanceRow.Fields.PageTitle());
    }
}
