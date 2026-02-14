using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.LeaveApprovalRow>;
using MyRow = HRMS.Operations.LeaveApprovalRow;

namespace HRMS.Operations;

public interface ILeaveApprovalListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveApprovalListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveApprovalListHandler
{
    public LeaveApprovalListHandler(IRequestContext context) : base(context) { }
}
