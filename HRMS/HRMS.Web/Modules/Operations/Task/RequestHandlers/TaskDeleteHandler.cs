using Serenity.Services;
using MyRow = HRMS.Operations.TaskRow;

namespace HRMS.Operations;

public interface ITaskDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> {}

public class TaskDeleteHandler : DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>, ITaskDeleteHandler
{
    public TaskDeleteHandler(IRequestContext context) : base(context)
    {
    }
}
