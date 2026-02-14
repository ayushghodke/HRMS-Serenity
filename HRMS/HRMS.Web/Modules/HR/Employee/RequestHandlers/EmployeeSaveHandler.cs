using Serenity.Services;
using MyRow = HRMS.HR.EmployeeRow;

namespace HRMS.HR;

public interface IEmployeeSaveHandler : ISaveHandler<MyRow, SaveRequest<MyRow>, SaveResponse> {}

public class EmployeeSaveHandler : SaveRequestHandler<MyRow, SaveRequest<MyRow>, SaveResponse>, IEmployeeSaveHandler
{
    public EmployeeSaveHandler(IRequestContext context) : base(context)
    {
    }

    protected override void BeforeSave()
    {
        base.BeforeSave();

        if (!Row.PaidLeavesPerMonth.HasValue || Row.PaidLeavesPerMonth.Value < 0)
            Row.PaidLeavesPerMonth = 2;
    }
}
