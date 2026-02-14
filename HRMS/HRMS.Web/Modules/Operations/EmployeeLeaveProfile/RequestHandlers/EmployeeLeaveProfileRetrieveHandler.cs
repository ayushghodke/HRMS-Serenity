using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.EmployeeLeaveProfileRow>;
using MyRow = HRMS.Operations.EmployeeLeaveProfileRow;

namespace HRMS.Operations;

public interface IEmployeeLeaveProfileRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeLeaveProfileRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeLeaveProfileRetrieveHandler
{
    public EmployeeLeaveProfileRetrieveHandler(IRequestContext context) : base(context) { }
}
