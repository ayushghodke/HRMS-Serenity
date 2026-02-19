using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<HRMS.Communication.SocialPlatformConfigRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = HRMS.Communication.SocialPlatformConfigRow;

namespace HRMS.Communication;

public interface ISocialPlatformConfigSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class SocialPlatformConfigSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISocialPlatformConfigSaveHandler
{
    public SocialPlatformConfigSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialPlatformConfigDeleteHandler : IDeleteHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse> {}

public class SocialPlatformConfigDeleteHandler : DeleteRequestHandler<MyRow, Serenity.Services.DeleteRequest, Serenity.Services.DeleteResponse>, ISocialPlatformConfigDeleteHandler
{
    public SocialPlatformConfigDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialPlatformConfigRetrieveHandler : IRetrieveHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>> {}

public class SocialPlatformConfigRetrieveHandler : RetrieveRequestHandler<MyRow, Serenity.Services.RetrieveRequest, Serenity.Services.RetrieveResponse<MyRow>>, ISocialPlatformConfigRetrieveHandler
{
    public SocialPlatformConfigRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}

public interface ISocialPlatformConfigListHandler : IListHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>> {}

public class SocialPlatformConfigListHandler : ListRequestHandler<MyRow, Serenity.Services.ListRequest, Serenity.Services.ListResponse<MyRow>>, ISocialPlatformConfigListHandler
{
    public SocialPlatformConfigListHandler(IRequestContext context)
            : base(context)
    {
    }
}
