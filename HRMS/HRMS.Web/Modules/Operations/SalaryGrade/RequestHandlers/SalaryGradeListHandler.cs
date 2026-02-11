using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<HRMS.Operations.SalaryGradeRow>;
using MyRow = HRMS.Operations.SalaryGradeRow;

namespace HRMS.Operations;

public interface ISalaryGradeListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryGradeListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryGradeListHandler
{
    public SalaryGradeListHandler(IRequestContext context)
         : base(context)
    {
    }
}
