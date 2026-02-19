using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Communication.SocialPostRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Communication.SocialPostRow;

namespace HRMS.Communication;

public interface ISocialPostSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class SocialPostSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISocialPostSaveHandler
{
    public SocialPostSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialPostDeleteHandler : IDeleteHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse> {}

public class SocialPostDeleteHandler : DeleteRequestHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse>, ISocialPostDeleteHandler
{
    public SocialPostDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialPostRetrieveHandler : IRetrieveHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>> {}

public class SocialPostRetrieveHandler : RetrieveRequestHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>>, ISocialPostRetrieveHandler
{
    public SocialPostRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialPostListHandler : IListHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>> {}

public class SocialPostListHandler : ListRequestHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>>, ISocialPostListHandler
{
    public SocialPostListHandler(IRequestContext context)
            : base(context)
    {
    }
}
