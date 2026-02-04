using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System.Data;
using MyRow = HRMS.Operations.AssetsRow;

namespace HRMS.Operations.Endpoints;

[Route("Services/Operations/Assets/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class AssetsEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAssetsSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAssetsSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] IAssetsDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] IAssetsRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] IAssetsListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse UpdateStatus(IUnitOfWork uow, AssetStatusUpdateRequest request,
        [FromServices] IAssetsSaveHandler handler)
    {
        var saveRequest = new SaveRequest<MyRow>
        {
            EntityId = request.AssetId,
            Entity = new MyRow
            {
                Status = (AssetStatus)request.NewStatus
            }
        };

        return handler.Update(uow, saveRequest);
    }
}

public class AssetStatusUpdateRequest : ServiceRequest
{
    public int AssetId { get; set; }
    public int NewStatus { get; set; }
}
