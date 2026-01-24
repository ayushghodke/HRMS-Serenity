using Serenity.Services;
using MyRow = HRMS.Operations.LeaveRow;

namespace HRMS.Operations;

public interface ILeaveDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> {}

public class LeaveDeleteHandler : DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>, ILeaveDeleteHandler
{
    public LeaveDeleteHandler(IRequestContext context) : base(context)
    {
    }
}
