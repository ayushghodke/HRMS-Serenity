using Serenity.Services;
using MyRow = HRMS.Operations.PayrollRow;

namespace HRMS.Operations;

public interface IPayrollListHandler : IListHandler<MyRow, ListRequest, ListResponse<MyRow>> {}

public class PayrollListHandler : ListRequestHandler<MyRow, ListRequest, ListResponse<MyRow>>, IPayrollListHandler
{
    public PayrollListHandler(IRequestContext context) : base(context)
    {
    }
}
