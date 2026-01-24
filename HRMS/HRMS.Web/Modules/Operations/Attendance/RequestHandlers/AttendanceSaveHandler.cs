using MyRow = HRMS.Operations.AttendanceRow;

namespace HRMS.Operations;

public interface IAttendanceSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class AttendanceSaveHandler(IRequestContext context) :
    SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IAttendanceSaveHandler
{
}