using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.HR.EmployeeSalaryRow;

namespace HRMS.HR;

public interface IEmployeeSalaryDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalaryDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalaryDeleteHandler
{
    public EmployeeSalaryDeleteHandler(IRequestContext context)
         : base(context)
    {
    }
}
