using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = HRMS.Recruitment.InterviewsRow;
using CandidateRow = HRMS.Recruitment.CandidatesRow;

namespace HRMS.Recruitment.Endpoints;

[Route("Services/Recruitment/Interviews/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class InterviewsEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IInterviewsSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IInterviewsSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] IInterviewsDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] IInterviewsRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] IInterviewsListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] IInterviewsListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.InterviewsColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "InterviewsList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse MarkDone(IUnitOfWork uow, [FromBody] MarkInterviewDoneRequest request)
    {
        var interview = uow.Connection.TryFirst<MyRow>(MyRow.Fields.InterviewId == request.InterviewId);
        if (interview == null)
            throw new ValidationError("InterviewNotFound", "Interview not found.");

        uow.Connection.UpdateById(new MyRow
        {
            InterviewId = request.InterviewId,
            IsCompleted = true,
            CompletedOn = DateTime.Now
        });

        if (interview.CandidateId != null)
        {
            uow.Connection.UpdateById(new CandidateRow
            {
                CandidateId = interview.CandidateId,
                Status = CandidateStatus.Interviewed
            });
        }

        return new ServiceResponse();
    }
}

public class MarkInterviewDoneRequest
{
    public int InterviewId { get; set; }
}
