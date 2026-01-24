using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.LeaveBalanceRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.LeaveBalanceRow;

namespace HRMS.Operations;

public interface ILeaveBalanceSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveBalanceSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveBalanceSaveHandler
{
    public LeaveBalanceSaveHandler(IRequestContext context) : base(context) { }
}
