using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace HRMS.Communication.Pages;

[PageAuthorize(typeof(NoticeRow))]
public class NoticePage : Controller
{
    [Route("Communication/Notice")]
    public ActionResult Index()
    {
        return this.GridPage("@/Communication/Notice/NoticePage",
            NoticeRow.Fields.PageTitle());
    }
}
