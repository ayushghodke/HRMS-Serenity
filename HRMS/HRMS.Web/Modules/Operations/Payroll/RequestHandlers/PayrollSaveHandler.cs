using Serenity.Services;
using MyRow = HRMS.Operations.PayrollRow;

namespace HRMS.Operations;

public interface IPayrollSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> {}

public class PayrollSaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>, IPayrollSaveHandler
{
    public PayrollSaveHandler(IRequestContext context)
         : base(context)
    {
    }

    protected override void BeforeSave()
    {
        base.BeforeSave();

        if (IsCreate)
        {
            Row.GeneratedDate = DateTime.Now;
        }
    }
}
