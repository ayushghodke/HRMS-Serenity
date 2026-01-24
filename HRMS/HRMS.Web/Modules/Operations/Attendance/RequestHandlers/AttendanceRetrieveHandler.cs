using MyRow = HRMS.Operations.AttendanceRow;

namespace HRMS.Operations;

public interface IAttendanceRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class AttendanceRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IAttendanceRetrieveHandler
{
}