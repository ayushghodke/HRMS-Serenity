using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.HR.Pages;

[PageAuthorize(typeof(EmployeeRow))]
public class EmployeePage : Controller
{
    [Route("HR/Employee")]
    public ActionResult Index()
    {
        return this.GridPage<EmployeeRow>("@/HR/Employee/EmployeePage");
    }
}
