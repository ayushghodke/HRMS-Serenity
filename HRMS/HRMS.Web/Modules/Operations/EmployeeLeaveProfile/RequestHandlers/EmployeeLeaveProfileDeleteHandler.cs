using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.EmployeeLeaveProfileRow;

namespace HRMS.Operations;

public interface IEmployeeLeaveProfileDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeLeaveProfileDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeLeaveProfileDeleteHandler
{
    public EmployeeLeaveProfileDeleteHandler(IRequestContext context) : base(context) { }
}
