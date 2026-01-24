using Serenity.Services;
using MyRow = HRMS.HR.EmployeeRow;

namespace HRMS.HR;

public interface IEmployeeListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> {}

public class EmployeeListHandler : ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>, IEmployeeListHandler
{
    public EmployeeListHandler(IRequestContext context) : base(context)
    {
    }
}
