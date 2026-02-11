using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = HRMS.Operations.SalaryGradeRow;

namespace HRMS.Operations;

public interface ISalaryGradeDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class SalaryGradeDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISalaryGradeDeleteHandler
{
    public SalaryGradeDeleteHandler(IRequestContext context)
         : base(context)
    {
    }
}
