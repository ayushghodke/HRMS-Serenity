using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(AssetsRow))]
public class AssetKanbanPage : Controller
{
    [Route("Operations/AssetKanban")]
    public ActionResult Index()
    {
        return View("~/Modules/Operations/Assets/AssetKanbanIndex.cshtml");
    }
}
