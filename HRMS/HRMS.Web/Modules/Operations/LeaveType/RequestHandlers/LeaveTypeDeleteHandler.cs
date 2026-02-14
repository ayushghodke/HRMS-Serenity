using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.LeaveTypeRow;

namespace HRMS.Operations;

public interface ILeaveTypeDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveTypeDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveTypeDeleteHandler
{
    public LeaveTypeDeleteHandler(IRequestContext context) : base(context) { }
}
