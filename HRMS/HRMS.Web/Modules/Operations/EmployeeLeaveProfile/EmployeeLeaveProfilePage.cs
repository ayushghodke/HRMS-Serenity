using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(EmployeeLeaveProfileRow))]
public class EmployeeLeaveProfilePage : Controller
{
    [Route("Operations/EmployeeLeaveProfile")]
    public ActionResult Index()
    {
        return this.GridPage<EmployeeLeaveProfileRow>("@/Operations/EmployeeLeaveProfile/EmployeeLeaveProfilePage");
    }
}
