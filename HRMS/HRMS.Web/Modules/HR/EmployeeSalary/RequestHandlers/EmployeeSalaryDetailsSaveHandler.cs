using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.HR.EmployeeSalaryDetailsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.HR.EmployeeSalaryDetailsRow;

namespace HRMS.HR;

public interface IEmployeeSalaryDetailsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalaryDetailsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalaryDetailsSaveHandler
{
    public EmployeeSalaryDetailsSaveHandler(IRequestContext context)
         : base(context)
    {
    }
}
