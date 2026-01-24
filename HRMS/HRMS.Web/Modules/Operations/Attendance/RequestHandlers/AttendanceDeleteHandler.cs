using MyRow = HRMS.Operations.AttendanceRow;

namespace HRMS.Operations;

public interface IAttendanceDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> { }

public class AttendanceDeleteHandler(IRequestContext context) :
    DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>(context),
    IAttendanceDeleteHandler
{
}