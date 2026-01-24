using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.LeaveBalanceRow>;
using MyRow = HRMS.Operations.LeaveBalanceRow;

namespace HRMS.Operations;

public interface ILeaveBalanceListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveBalanceListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveBalanceListHandler
{
    public LeaveBalanceListHandler(IRequestContext context) : base(context) { }
}
