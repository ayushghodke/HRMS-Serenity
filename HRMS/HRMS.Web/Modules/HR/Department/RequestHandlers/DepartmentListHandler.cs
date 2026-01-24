using Serenity.Services;
using MyRow = HRMS.HR.DepartmentRow;

namespace HRMS.HR;

public interface IDepartmentListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> {}

public class DepartmentListHandler : ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>, IDepartmentListHandler
{
    public DepartmentListHandler(IRequestContext context) : base(context)
    {
    }
}
