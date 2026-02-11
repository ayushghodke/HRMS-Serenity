using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.HR.EmployeeSalaryRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.HR.EmployeeSalaryRow;

namespace HRMS.HR;

public interface IEmployeeSalarySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeSalarySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeSalarySaveHandler
{
    public EmployeeSalarySaveHandler(IRequestContext context)
         : base(context)
    {
    }
}
