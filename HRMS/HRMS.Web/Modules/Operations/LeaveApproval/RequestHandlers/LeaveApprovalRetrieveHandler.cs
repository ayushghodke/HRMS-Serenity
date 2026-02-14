using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.LeaveApprovalRow>;
using MyRow = HRMS.Operations.LeaveApprovalRow;

namespace HRMS.Operations;

public interface ILeaveApprovalRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveApprovalRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveApprovalRetrieveHandler
{
    public LeaveApprovalRetrieveHandler(IRequestContext context) : base(context) { }
}
