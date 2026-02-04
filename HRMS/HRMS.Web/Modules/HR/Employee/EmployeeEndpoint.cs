using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = HRMS.HR.EmployeeRow;

namespace HRMS.HR.Endpoints;

[Route("Services/HR/Employee/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class EmployeeEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IEmployeeSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IEmployeeSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] IEmployeeDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] IEmployeeRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] IEmployeeListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] IEmployeeListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.EmployeeColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "EmployeeList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }
    [HttpPost, AuthorizeList(typeof(MyRow))]
    public UpcomingCelebrationsResponse GetUpcomingCelebrations(IDbConnection connection, UpcomingCelebrationsRequest request)
    {
        var days = request.Days ?? 30;
        
        var response = new UpcomingCelebrationsResponse
        {
            Birthdays = new List<MyRow>(),
            Anniversaries = new List<MyRow>()
        };

        // Birthdays Logic
        var sqlBirthdays = @"
            SELECT * FROM Employees 
            WHERE 
                (DATEADD(year, DATEDIFF(year, DateOfBirth, GETDATE()), DateOfBirth) BETWEEN GETDATE() AND DATEADD(day, @Days, GETDATE()))
                OR 
                (DATEADD(year, DATEDIFF(year, DateOfBirth, GETDATE()) + 1, DateOfBirth) BETWEEN GETDATE() AND DATEADD(day, @Days, GETDATE()))
            ORDER BY DATEPART(month, DateOfBirth), DATEPART(day, DateOfBirth)";

        response.Birthdays = connection.Query<MyRow>(sqlBirthdays, new { Days = days }).ToList();

        // Anniversaries Logic
        var sqlAnniversaries = @"
            SELECT * FROM Employees 
            WHERE 
                (DATEADD(year, DATEDIFF(year, JoiningDate, GETDATE()), JoiningDate) BETWEEN GETDATE() AND DATEADD(day, @Days, GETDATE()))
                OR 
                (DATEADD(year, DATEDIFF(year, JoiningDate, GETDATE()) + 1, JoiningDate) BETWEEN GETDATE() AND DATEADD(day, @Days, GETDATE()))
            ORDER BY DATEPART(month, JoiningDate), DATEPART(day, JoiningDate)";
            
        response.Anniversaries = connection.Query<MyRow>(sqlAnniversaries, new { Days = days }).ToList();

        return response;
    }
}

public class UpcomingCelebrationsRequest : ServiceRequest
{
    public int? Days { get; set; }
}

public class UpcomingCelebrationsResponse : ServiceResponse
{
    public List<MyRow> Birthdays { get; set; }
    public List<MyRow> Anniversaries { get; set; }
}
