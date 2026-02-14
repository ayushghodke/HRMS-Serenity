using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.LeaveTypeRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.LeaveTypeRow;

namespace HRMS.Operations;

public interface ILeaveTypeSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveTypeSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveTypeSaveHandler
{
    public LeaveTypeSaveHandler(IRequestContext context) : base(context) { }
}
