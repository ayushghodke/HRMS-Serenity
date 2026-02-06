using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = HRMS.Operations.TaskRow;
using HRMS.Operations;
using HRMS.Operations.Columns;

namespace HRMS.Operations.Endpoints;

[Route("Services/Operations/Task/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class TaskEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ITaskSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ITaskSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] ITaskDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] ITaskRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] ITaskListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] ITaskListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.TaskColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "TaskList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }
    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse UpdateStatus(IUnitOfWork uow, TaskUpdateStatusRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request.TaskId == null) throw new ArgumentNullException(nameof(request.TaskId));

        var row = new MyRow
        {
            TaskId = request.TaskId,
            Status = request.NewStatus
        };

        return new TaskSaveHandler(Context).Update(uow, new SaveRequest<MyRow> { Entity = row, EntityId = request.TaskId });
    }
}

public class TaskUpdateStatusRequest : ServiceRequest
{
    public int? TaskId { get; set; }
    public HRMS.Operations.TaskStatus NewStatus { get; set; }
}
