using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.LeaveTypeRow>;
using MyRow = HRMS.Operations.LeaveTypeRow;

namespace HRMS.Operations;

public interface ILeaveTypeListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveTypeListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveTypeListHandler
{
    public LeaveTypeListHandler(IRequestContext context) : base(context) { }
}
