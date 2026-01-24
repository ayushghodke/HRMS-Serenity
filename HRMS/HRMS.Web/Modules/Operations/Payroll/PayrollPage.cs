using Microsoft.AspNetCore.Mvc;
using Serenity.Web;
using HRMS.Operations;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(PayrollRow))]
public class PayrollPage : Controller
{
    [Route("Operations/Payroll")]
    public ActionResult Index()
    {
        return this.GridPage<PayrollRow>("@/Operations/Payroll/PayrollPage");
    }
}
