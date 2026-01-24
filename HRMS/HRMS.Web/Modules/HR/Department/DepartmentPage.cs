using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.HR.Pages;

[PageAuthorize(typeof(DepartmentRow))]
public class DepartmentPage : Controller
{
    [Route("HR/Department")]
    public ActionResult Index()
    {
        return this.GridPage<DepartmentRow>("@/HR/Department/DepartmentPage");
    }
}
