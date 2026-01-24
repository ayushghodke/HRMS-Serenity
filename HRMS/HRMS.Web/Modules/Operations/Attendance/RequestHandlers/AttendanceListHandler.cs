using MyRow = HRMS.Operations.AttendanceRow;

namespace HRMS.Operations;

public interface IAttendanceListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> { }

public class AttendanceListHandler(IRequestContext context) :
    ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IAttendanceListHandler
{
}