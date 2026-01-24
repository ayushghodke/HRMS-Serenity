using Serenity.Services;
using MyRow = HRMS.Operations.TaskRow;

namespace HRMS.Operations;

public interface ITaskSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> {}

public class TaskSaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>, ITaskSaveHandler
{
    public TaskSaveHandler(IRequestContext context) : base(context)
    {
    }
}
