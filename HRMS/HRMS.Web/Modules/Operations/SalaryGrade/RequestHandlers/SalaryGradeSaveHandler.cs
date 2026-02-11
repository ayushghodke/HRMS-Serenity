using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.SalaryGradeRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.SalaryGradeRow;

namespace HRMS.Operations;

public interface ISalaryGradeSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryGradeSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryGradeSaveHandler
{
    public SalaryGradeSaveHandler(IRequestContext context)
         : base(context)
    {
    }
}
