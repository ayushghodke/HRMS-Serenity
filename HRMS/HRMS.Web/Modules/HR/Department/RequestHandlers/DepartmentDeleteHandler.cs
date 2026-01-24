using Serenity.Services;
using MyRow = HRMS.HR.DepartmentRow;

namespace HRMS.HR;

public interface IDepartmentDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> {}

public class DepartmentDeleteHandler : DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>, IDepartmentDeleteHandler
{
    public DepartmentDeleteHandler(IRequestContext context) : base(context)
    {
    }
}
