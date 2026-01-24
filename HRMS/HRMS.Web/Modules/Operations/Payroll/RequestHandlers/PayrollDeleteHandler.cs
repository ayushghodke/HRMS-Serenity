using Serenity.Services;
using MyRow = HRMS.Operations.PayrollRow;

namespace HRMS.Operations;

public interface IPayrollDeleteHandler : IDeleteHandler<MyRow, DeleteRequest, DeleteResponse> {}

public class PayrollDeleteHandler : DeleteRequestHandler<MyRow, DeleteRequest, DeleteResponse>, IPayrollDeleteHandler
{
    public PayrollDeleteHandler(IRequestContext context) : base(context)
    {
    }
}
