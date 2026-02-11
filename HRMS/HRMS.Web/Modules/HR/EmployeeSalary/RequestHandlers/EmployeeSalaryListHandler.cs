using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.HR.EmployeeSalaryRow>;
using MyRow = HRMS.HR.EmployeeSalaryRow;

namespace HRMS.HR;

public interface IEmployeeSalaryListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalaryListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalaryListHandler
{
    public EmployeeSalaryListHandler(IRequestContext context)
         : base(context)
    {
    }
}
