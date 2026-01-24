using Serenity.Services;
using MyRow = HRMS.HR.DesignationRow;

namespace HRMS.HR;

public interface IDesignationSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> {}

public class DesignationSaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>, IDesignationSaveHandler
{
    public DesignationSaveHandler(IRequestContext context) : base(context)
    {
    }
}
