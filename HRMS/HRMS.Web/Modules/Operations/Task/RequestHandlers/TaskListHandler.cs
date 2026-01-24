using Serenity.Services;
using MyRow = HRMS.Operations.TaskRow;

namespace HRMS.Operations;

public interface ITaskListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> {}

public class TaskListHandler : ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>, ITaskListHandler
{
    public TaskListHandler(IRequestContext context) : base(context)
    {
    }
}
