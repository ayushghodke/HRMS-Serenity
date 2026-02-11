using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<HRMS.Operations.SalaryGradeRow>;
using MyRow = HRMS.Operations.SalaryGradeRow;

namespace HRMS.Operations;

public interface ISalaryGradeRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryGradeRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryGradeRetrieveHandler
{
    public SalaryGradeRetrieveHandler(IRequestContext context)
         : base(context)
    {
    }
}
