using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(SalaryGradeRow))]
public class SalaryGradePage : Controller
{
    [Route("Operations/SalaryGrade")]
    public ActionResult Index()
    {
        return this.GridPage("@/Operations/SalaryGrade/SalaryGradePage",
            SalaryGradeRow.Fields.PageTitle());
    }
}
