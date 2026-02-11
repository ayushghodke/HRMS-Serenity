using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.HR.EmployeeSalaryDetailsRow>;
using MyRow = HRMS.HR.EmployeeSalaryDetailsRow;

namespace HRMS.HR;

public interface IEmployeeSalaryDetailsListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalaryDetailsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalaryDetailsListHandler
{
    public EmployeeSalaryDetailsListHandler(IRequestContext context)
         : base(context)
    {
    }
}
