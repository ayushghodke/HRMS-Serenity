namespace HRMS.Operations.Pages;

[PageAuthorize(typeof(AttendanceRow))]
public class AttendancePage : Controller
{
    [Route("Operations/Attendance")]
    public ActionResult Index()
    {
        return this.GridPage<AttendanceRow>("@/Operations/Attendance/AttendancePage");
    }
}