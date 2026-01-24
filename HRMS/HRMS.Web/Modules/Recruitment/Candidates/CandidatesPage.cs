namespace HRMS.Recruitment.Pages;

[PageAuthorize(typeof(CandidatesRow))]
public class CandidatesPage : Controller
{
    [Route("Recruitment/Candidates")]
    public ActionResult Index()
    {
        return this.GridPage<CandidatesRow>("@/Recruitment/Candidates/CandidatesPage");
    }
}