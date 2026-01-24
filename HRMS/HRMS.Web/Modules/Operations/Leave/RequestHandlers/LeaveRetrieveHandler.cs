using Serenity.Services;
using MyRow = HRMS.Operations.LeaveRow;

namespace HRMS.Operations;

public interface ILeaveRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> {}

public class LeaveRetrieveHandler : RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>, ILeaveRetrieveHandler
{
    public LeaveRetrieveHandler(IRequestContext context) : base(context)
    {
    }
}
