using Serenity.Services;
using System;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Operations.EmployeeLeaveProfileRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Operations.EmployeeLeaveProfileRow;

namespace HRMS.Operations;

public interface IEmployeeLeaveProfileSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class EmployeeLeaveProfileSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeLeaveProfileSaveHandler
{
    public EmployeeLeaveProfileSaveHandler(IRequestContext context) : base(context) { }

    protected override void BeforeSave()
    {
        base.BeforeSave();
        Row.LastUpdatedDate = DateTime.Now;
    }
}
