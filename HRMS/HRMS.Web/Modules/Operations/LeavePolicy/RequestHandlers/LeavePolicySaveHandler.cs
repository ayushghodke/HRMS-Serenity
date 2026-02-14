using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.LeavePolicyRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.LeavePolicyRow;

namespace HRMS.Operations;

public interface ILeavePolicySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class LeavePolicySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILeavePolicySaveHandler
{
    public LeavePolicySaveHandler(IRequestContext context) : base(context) { }

    protected override void BeforeSave()
    {
        base.BeforeSave();
        if (!Row.PayrollCutoffDay.HasValue || Row.PayrollCutoffDay.Value <= 0 || Row.PayrollCutoffDay.Value > 30)
            Row.PayrollCutoffDay = 30;

        Row.ApprovalLevels = ApprovalLevelMode.FixedTwoLevel;
    }
}
