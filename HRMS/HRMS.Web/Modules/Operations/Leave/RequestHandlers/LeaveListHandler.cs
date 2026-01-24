using Serenity.Services;
using MyRow = HRMS.Operations.LeaveRow;

namespace HRMS.Operations;

public interface ILeaveListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> {}

public class LeaveListHandler : ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>, ILeaveListHandler
{
    public LeaveListHandler(IRequestContext context) : base(context)
    {
    }
}
