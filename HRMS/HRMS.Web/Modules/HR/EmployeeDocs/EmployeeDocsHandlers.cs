using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.HR.EmployeeDocsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.HR.EmployeeDocsRow;

namespace HRMS.HR;

public interface IEmployeeDocsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class EmployeeDocsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IEmployeeDocsSaveHandler
{
    public EmployeeDocsSaveHandler(IRequestContext context)
            : base(context) 
    {
    }

    protected override void BeforeSave()
    {
        base.BeforeSave();
        
        if (IsCreate)
        {
            if (Row.UploadedOn == null)
                Row.UploadedOn = DateTime.Now;
        }
    }
}

public interface IEmployeeDocsDeleteHandler : IDeleteHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse> {}

public class EmployeeDocsDeleteHandler : DeleteRequestHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse>, IEmployeeDocsDeleteHandler
{
    public EmployeeDocsDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface IEmployeeDocsRetrieveHandler : IRetrieveHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>> {}

public class EmployeeDocsRetrieveHandler : RetrieveRequestHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>>, IEmployeeDocsRetrieveHandler
{
    public EmployeeDocsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface IEmployeeDocsListHandler : IListHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>> {}

public class EmployeeDocsListHandler : ListRequestHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>>, IEmployeeDocsListHandler
{
    public EmployeeDocsListHandler(IRequestContext context)
            : base(context)
    {
    }
}
