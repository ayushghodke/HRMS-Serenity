using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Recruitment.Pages;

[PageAuthorize(typeof(CandidatesRow))]
public class CandidateKanbanPage : Controller
{
    [Route("Recruitment/CandidateKanban")]
    public ActionResult Index()
    {
        return View("~/Modules/Recruitment/CandidateKanban/CandidateKanbanIndex.cshtml");
    }
}
