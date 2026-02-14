using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.EmployeeLeaveProfileRow>;
using MyRow = HRMS.Operations.EmployeeLeaveProfileRow;

namespace HRMS.Operations;

public interface IEmployeeLeaveProfileListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeLeaveProfileListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeLeaveProfileListHandler
{
    public EmployeeLeaveProfileListHandler(IRequestContext context) : base(context) { }
}
