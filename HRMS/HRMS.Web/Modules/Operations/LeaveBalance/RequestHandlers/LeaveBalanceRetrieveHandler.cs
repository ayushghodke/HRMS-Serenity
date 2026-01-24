using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.LeaveBalanceRow>;
using MyRow = HRMS.Operations.LeaveBalanceRow;

namespace HRMS.Operations;

public interface ILeaveBalanceRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveBalanceRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveBalanceRetrieveHandler
{
    public LeaveBalanceRetrieveHandler(IRequestContext context) : base(context) { }
}
