using Serenity.Services;
using System;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.LeaveApprovalRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.LeaveApprovalRow;

namespace HRMS.Operations;

public interface ILeaveApprovalSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class LeaveApprovalSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILeaveApprovalSaveHandler
{
    public LeaveApprovalSaveHandler(IRequestContext context) : base(context) { }

    protected override void BeforeSave()
    {
        base.BeforeSave();
        if (!Row.ApprovalDate.HasValue)
            Row.ApprovalDate = DateTime.Now;
        Row.TimeStamp = DateTime.Now;
    }
}
