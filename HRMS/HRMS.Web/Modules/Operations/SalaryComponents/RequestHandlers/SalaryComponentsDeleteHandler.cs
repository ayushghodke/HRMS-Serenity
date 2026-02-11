using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.SalaryComponentsRow;

namespace HRMS.Operations;

public interface ISalaryComponentsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryComponentsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryComponentsDeleteHandler
{
    public SalaryComponentsDeleteHandler(IRequestContext context)
         : base(context)
    {
    }
}
