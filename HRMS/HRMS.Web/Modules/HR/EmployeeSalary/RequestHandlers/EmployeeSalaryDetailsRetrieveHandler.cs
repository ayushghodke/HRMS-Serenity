using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.HR.EmployeeSalaryDetailsRow>;
using MyRow = HRMS.HR.EmployeeSalaryDetailsRow;

namespace HRMS.HR;

public interface IEmployeeSalaryDetailsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalaryDetailsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalaryDetailsRetrieveHandler
{
    public EmployeeSalaryDetailsRetrieveHandler(IRequestContext context)
         : base(context)
    {
    }
}
