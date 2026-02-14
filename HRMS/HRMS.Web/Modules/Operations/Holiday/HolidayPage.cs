using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(HolidayRow))]
public class HolidayPage : Controller
{
    [Route("Operations/Holiday")]
    public ActionResult Index()
    {
        return this.GridPage<HolidayRow>("@/Operations/Holiday/HolidayPage");
    }
}
