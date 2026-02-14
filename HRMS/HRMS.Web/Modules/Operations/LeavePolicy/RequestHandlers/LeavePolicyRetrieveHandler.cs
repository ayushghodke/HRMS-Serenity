using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.LeavePolicyRow>;
using MyRow = HRMS.Operations.LeavePolicyRow;

namespace HRMS.Operations;

public interface ILeavePolicyRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class LeavePolicyRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ILeavePolicyRetrieveHandler
{
    public LeavePolicyRetrieveHandler(IRequestContext context) : base(context) { }
}
