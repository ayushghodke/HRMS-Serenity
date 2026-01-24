using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Recruitment.Pages;

[PageAuthorize(typeof(InterviewsRow))]
public class InterviewsPage : Controller
{
    [Route("Recruitment/Interviews")]
    public ActionResult Index()
    {
        return this.GridPage<InterviewsRow>("@/Recruitment/Interviews/InterviewsPage");
    }
}
