using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Communication.NoticeRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Communication.NoticeRow;

namespace HRMS.Communication;

public interface INoticeSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class NoticeSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, INoticeSaveHandler
{
    public NoticeSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface INoticeDeleteHandler : IDeleteHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse> {}

public class NoticeDeleteHandler : DeleteRequestHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse>, INoticeDeleteHandler
{
    public NoticeDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface INoticeRetrieveHandler : IRetrieveHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>> {}

public class NoticeRetrieveHandler : RetrieveRequestHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>>, INoticeRetrieveHandler
{
    public NoticeRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface INoticeListHandler : IListHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>> {}

public class NoticeListHandler : ListRequestHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>>, INoticeListHandler
{
    public NoticeListHandler(IRequestContext context)
            : base(context)
    {
    }
}
