using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.LeaveTypeRow>;
using MyRow = HRMS.Operations.LeaveTypeRow;

namespace HRMS.Operations;

public interface ILeaveTypeRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveTypeRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveTypeRetrieveHandler
{
    public LeaveTypeRetrieveHandler(IRequestContext context) : base(context) { }
}
