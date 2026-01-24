using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.HR.Pages;

[PageAuthorize(typeof(DesignationRow))]
public class DesignationPage : Controller
{
    [Route("HR/Designation")]
    public ActionResult Index()
    {
        return this.GridPage<DesignationRow>("@/HR/Designation/DesignationPage");
    }
}
