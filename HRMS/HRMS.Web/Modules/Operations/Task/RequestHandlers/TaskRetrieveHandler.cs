using Serenity.Services;
using MyRow = HRMS.Operations.TaskRow;

namespace HRMS.Operations;

public interface ITaskRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> {}

public class TaskRetrieveHandler : RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>, ITaskRetrieveHandler
{
    public TaskRetrieveHandler(IRequestContext context) : base(context)
    {
    }
}
