using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.HR.Pages;

[PageAuthorize(typeof(EmployeeSalaryRow))]
public class EmployeeSalaryPage : Controller
{
    [Route("HR/EmployeeSalary")]
    public ActionResult Index()
    {
        return this.GridPage<EmployeeSalaryRow>("@/Modules/HR/EmployeeSalary/EmployeeSalaryPage.tsx");
    }
}
