using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.LeavePolicyRow;

namespace HRMS.Operations;

public interface ILeavePolicyDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class LeavePolicyDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ILeavePolicyDeleteHandler
{
    public LeavePolicyDeleteHandler(IRequestContext context) : base(context) { }
}
