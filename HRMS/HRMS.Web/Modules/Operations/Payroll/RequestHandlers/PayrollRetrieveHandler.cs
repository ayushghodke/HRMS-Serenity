using Serenity.Services;
using MyRow = HRMS.Operations.PayrollRow;

namespace HRMS.Operations;

public interface IPayrollRetrieveHandler : IRetrieveHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> {}

public class PayrollRetrieveHandler : RetrieveRequestHandler<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>, IPayrollRetrieveHandler
{
    public PayrollRetrieveHandler(IRequestContext context) : base(context)
    {
    }
}
