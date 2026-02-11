using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.HR.EmployeeSalaryDetailsRow;

namespace HRMS.HR;

public interface IEmployeeSalaryDetailsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalaryDetailsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalaryDetailsDeleteHandler
{
    public EmployeeSalaryDetailsDeleteHandler(IRequestContext context)
         : base(context)
    {
    }
}
