using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Communication.SocialAccountRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Communication.SocialAccountRow;

namespace HRMS.Communication;

public interface ISocialAccountSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class SocialAccountSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISocialAccountSaveHandler
{
    public SocialAccountSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialAccountDeleteHandler : IDeleteHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse> {}

public class SocialAccountDeleteHandler : DeleteRequestHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse>, ISocialAccountDeleteHandler
{
    public SocialAccountDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialAccountRetrieveHandler : IRetrieveHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>> {}

public class SocialAccountRetrieveHandler : RetrieveRequestHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>>, ISocialAccountRetrieveHandler
{
    public SocialAccountRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialAccountListHandler : IListHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>> {}

public class SocialAccountListHandler : ListRequestHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>>, ISocialAccountListHandler
{
    public SocialAccountListHandler(IRequestContext context)
            : base(context)
    {
    }
}
