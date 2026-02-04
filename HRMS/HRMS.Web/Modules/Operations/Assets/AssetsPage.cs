using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(AssetsRow))]
public class AssetsPage : Controller
{
    [Route("Operations/Assets")]
    public ActionResult Index()
    {
        return this.GridPage<AssetsRow>("@/Operations/Assets/AssetsPage");
    }
}
