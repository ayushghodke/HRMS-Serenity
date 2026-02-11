using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(SalaryComponentsRow))]
public class SalaryComponentsPage : Controller
{
    [Route("Operations/SalaryComponents")]
    public ActionResult Index()
    {
        return this.GridPage("@/Operations/SalaryComponents/SalaryComponentsPage",
            SalaryComponentsRow.Fields.PageTitle());
    }
}
