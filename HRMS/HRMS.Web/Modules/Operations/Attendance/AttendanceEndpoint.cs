using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = HRMS.Operations.AttendanceRow;

namespace HRMS.Operations.Endpoints;

[Route("Services/Operations/Attendance/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class AttendanceEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAttendanceSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAttendanceSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] IAttendanceDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] IAttendanceRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] IAttendanceListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] IAttendanceListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.AttendanceColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "AttendanceList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, Authorize]
    public SaveResponse PunchIn(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAttendanceSaveHandler handler)
    {
        var userId = int.Parse(User.GetIdentifier());
        var today = DateTime.Today;

        var user = uow.Connection.ById<HRMS.Administration.UserRow>(userId);
        if (user == null)
            throw new ValidationError("User Not Found", "Could not retrieve user details.");

        var fld = MyRow.Fields;
        var existingPunch = uow.Connection.TryFirst<MyRow>(
            fld.Name == userId & fld.PunchIn >= today);

        if (existingPunch != null)
            throw new ValidationError("Already Punched In", "You have already punched in today.");

        if (request.Entity == null || string.IsNullOrEmpty(request.Entity.Coordinates))
            throw new ValidationError("Location Error", "Coordinates are required.");

        var row = new MyRow
        {
            UserId = user.Username,
            PunchIn = DateTime.Now,
            DateNTime = DateTime.Now,
            Type = AttendanceType.HalfDay,
            Coordinates = request.Entity.Coordinates,
            Location = request.Entity.Location ?? "Unknown",
            Name = userId 
        };

        return handler.Create(uow, new SaveRequest<MyRow> { Entity = row });
    }

    [HttpPost, Authorize]
    public SaveResponse PunchOut(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAttendanceSaveHandler handler)
    {
        var userId = int.Parse(User.GetIdentifier());
        var today = DateTime.Today;

        var fld = MyRow.Fields;
        var existingPunch = uow.Connection.TryFirst<MyRow>(
            fld.Name == userId & fld.PunchIn >= today);

        if (existingPunch == null || existingPunch.PunchIn == null)
            throw new ValidationError("Punch-in Not Found", "You need to punch in before punching out.");

        if (request.Entity == null || string.IsNullOrEmpty(request.Entity.PunchOutCoordinates))
            throw new ValidationError("Location Error", "Punch-out coordinates are required.");

        existingPunch.PunchOut = DateTime.Now;
        existingPunch.PunchOutCoordinates = request.Entity.PunchOutCoordinates;

        // Calculate duration
        var duration = (existingPunch.PunchOut.Value - existingPunch.PunchIn.Value).TotalHours;

        // Set attendance type
        existingPunch.Type = duration >= 4
            ? AttendanceType.Present
            : AttendanceType.HalfDay;

        return handler.Update(uow, new SaveRequest<MyRow> 
        { 
            EntityId = existingPunch.Id,
            Entity = existingPunch 
        });
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse Approve(IDbConnection connection, SaveRequest<MyRow> request)
    {
        var userId = int.Parse(User.GetIdentifier());
        connection.Execute("UPDATE Attendance SET ApprovedBy = @approvedBy WHERE Id = @id", 
            new { approvedBy = userId, id = request.EntityId });

        return new ServiceResponse();
    }
}