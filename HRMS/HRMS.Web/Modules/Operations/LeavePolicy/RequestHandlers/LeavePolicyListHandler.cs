using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.LeavePolicyRow>;
using MyRow = HRMS.Operations.LeavePolicyRow;

namespace HRMS.Operations;

public interface ILeavePolicyListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class LeavePolicyListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILeavePolicyListHandler
{
    public LeavePolicyListHandler(IRequestContext context) : base(context) { }
}
