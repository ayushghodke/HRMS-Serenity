using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.LeaveBalanceRow;

namespace HRMS.Operations;

public interface ILeaveBalanceDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveBalanceDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveBalanceDeleteHandler
{
    public LeaveBalanceDeleteHandler(IRequestContext context) : base(context) { }
}
