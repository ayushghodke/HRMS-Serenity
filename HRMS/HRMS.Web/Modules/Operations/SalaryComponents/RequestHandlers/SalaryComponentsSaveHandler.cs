using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.SalaryComponentsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.SalaryComponentsRow;

namespace HRMS.Operations;

public interface ISalaryComponentsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryComponentsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryComponentsSaveHandler
{
    public SalaryComponentsSaveHandler(IRequestContext context)
         : base(context)
    {
    }
}
