using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.LeaveApprovalRow;

namespace HRMS.Operations;

public interface ILeaveApprovalDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveApprovalDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveApprovalDeleteHandler
{
    public LeaveApprovalDeleteHandler(IRequestContext context) : base(context) { }
}
