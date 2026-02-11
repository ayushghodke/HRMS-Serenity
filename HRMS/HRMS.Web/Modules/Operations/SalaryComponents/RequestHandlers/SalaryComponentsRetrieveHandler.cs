using Serenity.Services;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.SalaryComponentsRow>;
using MyRow = HRMS.Operations.SalaryComponentsRow;

namespace HRMS.Operations;

public interface ISalaryComponentsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryComponentsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryComponentsRetrieveHandler
{
    public SalaryComponentsRetrieveHandler(IRequestContext context)
         : base(context)
    {
    }
}
