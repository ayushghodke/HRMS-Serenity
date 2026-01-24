using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Recruitment.Pages;

[PageAuthorize(typeof(JobOpeningsRow))]
public class JobOpeningsPage : Controller
{
    [Route("Recruitment/JobOpenings")]
    public ActionResult Index()
    {
        return this.GridPage<JobOpeningsRow>("@/Recruitment/JobOpenings/JobOpeningsPage");
    }
}
