using Serenity.Reporting;
using System.Data;
using System.Globalization;
using MyRow = HRMS.Recruitment.CandidatesRow;

namespace HRMS.Recruitment.Endpoints;

[Route("Services/Recruitment/Candidates/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class CandidatesEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ICandidatesSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ICandidatesSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] ICandidatesDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] ICandidatesRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] ICandidatesListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] ICandidatesListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.CandidatesColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "CandidatesList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse UpdateStatus(IUnitOfWork uow, [FromBody] UpdateStatusRequest request)
    {
        var candidate = uow.Connection.TryFirst<MyRow>(MyRow.Fields.CandidateId == request.CandidateId);
        if (candidate == null)
            throw new ValidationError("CandidateNotFound", "Candidate not found.");

        uow.Connection.UpdateById(new MyRow
        {
            CandidateId = request.CandidateId,
            Status = request.NewStatus
        });

        return new ServiceResponse();
    }
}

public class UpdateStatusRequest
{
    public int CandidateId { get; set; }
    public CandidateStatus NewStatus { get; set; }
}