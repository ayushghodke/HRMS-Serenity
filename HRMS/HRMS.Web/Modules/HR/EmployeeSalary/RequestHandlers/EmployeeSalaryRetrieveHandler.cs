using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.HR.EmployeeSalaryRow>;
using MyRow = HRMS.HR.EmployeeSalaryRow;

namespace HRMS.HR;

public interface IEmployeeSalaryRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalaryRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalaryRetrieveHandler
{
    public EmployeeSalaryRetrieveHandler(IRequestContext context)
         : base(context)
    {
    }
}
