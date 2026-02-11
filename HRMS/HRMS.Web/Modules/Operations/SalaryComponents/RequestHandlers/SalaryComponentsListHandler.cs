using Serenity.Services;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.SalaryComponentsRow>;
using MyRow = HRMS.Operations.SalaryComponentsRow;

namespace HRMS.Operations;

public interface ISalaryComponentsListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryComponentsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryComponentsListHandler
{
    public SalaryComponentsListHandler(IRequestContext context)
         : base(context)
    {
    }
}
