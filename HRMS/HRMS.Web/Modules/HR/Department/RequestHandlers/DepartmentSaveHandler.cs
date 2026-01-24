using Serenity.Services;
using MyRow = HRMS.HR.DepartmentRow;

namespace HRMS.HR;

public interface IDepartmentSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> {}

public class DepartmentSaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>, IDepartmentSaveHandler
{
    public DepartmentSaveHandler(IRequestContext context) : base(context)
    {
    }
}
