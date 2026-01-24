using Serenity.Services;
using MyRow = HRMS.Operations.LeaveRow;

namespace HRMS.Operations;

public interface ILeaveSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> {}

public class LeaveSaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>, ILeaveSaveHandler
{
    public LeaveSaveHandler(IRequestContext context) : base(context)
    {
    }
}
