using Serenity.Services;
using MyRow = HRMS.HR.EmployeeRow;

namespace HRMS.HR;

public interface IEmployeeDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> {}

public class EmployeeDeleteHandler : DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>, IEmployeeDeleteHandler
{
    public EmployeeDeleteHandler(IRequestContext context) : base(context)
    {
    }
}
