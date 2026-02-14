using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace HRMS.Operations.Endpoints;

[Route("Services/Operations/LeaveReports/[action]")]
[ConnectionKey(typeof(LeaveRow)), ServiceAuthorize(typeof(LeaveRow))]
public class LeaveReportsEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public ListResponse<LeaveReportRow> LeaveHistory(IDbConnection connection, LeaveReportFilterRequest request)
    {
        var list = connection.Query<LeaveReportRow>(BuildLeaveHistorySql(request), BuildParams(request)).ToList();
        return new ListResponse<LeaveReportRow> { Entities = list };
    }

    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public ListResponse<DepartmentLeaveSummaryRow> DepartmentSummary(IDbConnection connection, LeaveReportFilterRequest request)
    {
        var sql = @"
            SELECT
                ISNULL(d.DepartmentName, 'Unassigned') AS DepartmentName,
                ISNULL(SUM(ISNULL(l.TotalDays, 0)), 0) AS TotalLeaves,
                ISNULL(SUM(ISNULL(l.PaidDays, 0)), 0) AS PaidDays,
                ISNULL(SUM(ISNULL(l.UnpaidDays, 0)), 0) AS UnpaidDays,
                SUM(CASE WHEN l.FinalStatus = 0 THEN 1 ELSE 0 END) AS PendingCount
            FROM Leaves l
            INNER JOIN Employees e ON e.EmployeeId = l.EmployeeId
            LEFT JOIN Departments d ON d.DepartmentId = e.DepartmentId
            WHERE (@EmployeeId IS NULL OR e.EmployeeId = @EmployeeId)
              AND (@DepartmentId IS NULL OR e.DepartmentId = @DepartmentId)
              AND (@LeaveTypeId IS NULL OR l.LeaveTypeId = @LeaveTypeId)
              AND (@DateFrom IS NULL OR l.StartDate >= @DateFrom)
              AND (@DateTo IS NULL OR l.EndDate <= @DateTo)
            GROUP BY d.DepartmentName
            ORDER BY d.DepartmentName
        ";

        var list = connection.Query<DepartmentLeaveSummaryRow>(sql, BuildParams(request)).ToList();
        return new ListResponse<DepartmentLeaveSummaryRow> { Entities = list };
    }

    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public ListResponse<MonthlyLeaveSummaryRow> MonthlySummary(IDbConnection connection, LeaveReportFilterRequest request)
    {
        var sql = @"
            SELECT
                FORMAT(CAST(l.StartDate AS DATE), 'MMM yyyy') AS MonthLabel,
                ISNULL(SUM(ISNULL(l.TotalDays, 0)), 0) AS TotalLeaves,
                ISNULL(SUM(ISNULL(l.PaidDays, 0)), 0) AS PaidDays,
                ISNULL(SUM(ISNULL(l.UnpaidDays, 0)), 0) AS UnpaidDays
            FROM Leaves l
            INNER JOIN Employees e ON e.EmployeeId = l.EmployeeId
            WHERE (@EmployeeId IS NULL OR e.EmployeeId = @EmployeeId)
              AND (@DepartmentId IS NULL OR e.DepartmentId = @DepartmentId)
              AND (@LeaveTypeId IS NULL OR l.LeaveTypeId = @LeaveTypeId)
              AND (@DateFrom IS NULL OR l.StartDate >= @DateFrom)
              AND (@DateTo IS NULL OR l.EndDate <= @DateTo)
            GROUP BY YEAR(l.StartDate), MONTH(l.StartDate), FORMAT(CAST(l.StartDate AS DATE), 'MMM yyyy')
            ORDER BY YEAR(l.StartDate), MONTH(l.StartDate)
        ";

        var list = connection.Query<MonthlyLeaveSummaryRow>(sql, BuildParams(request)).ToList();
        return new ListResponse<MonthlyLeaveSummaryRow> { Entities = list };
    }

    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public FileContentResult LeaveHistoryExcel(IDbConnection connection, LeaveReportFilterRequest request,
        [FromServices] IExcelExporter exporter)
    {
        var data = LeaveHistory(connection, request).Entities;
        var bytes = exporter.Export(data, typeof(LeaveReportRow), null);
        return ExcelContentResult.Create(bytes, "LeaveHistory_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public FileContentResult DepartmentSummaryExcel(IDbConnection connection, LeaveReportFilterRequest request,
        [FromServices] IExcelExporter exporter)
    {
        var data = DepartmentSummary(connection, request).Entities;
        var bytes = exporter.Export(data, typeof(DepartmentLeaveSummaryRow), null);
        return ExcelContentResult.Create(bytes, "DepartmentLeaveSummary_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public FileContentResult MonthlySummaryExcel(IDbConnection connection, LeaveReportFilterRequest request,
        [FromServices] IExcelExporter exporter)
    {
        var data = MonthlySummary(connection, request).Entities;
        var bytes = exporter.Export(data, typeof(MonthlyLeaveSummaryRow), null);
        return ExcelContentResult.Create(bytes, "MonthlyLeaveSummary_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public ServiceResponse ExportPdf(LeaveReportPdfRequest request)
    {
        return new ServiceResponse
        {
            Error = new ServiceError
            {
                Code = "PdfReportPending",
                Message = "PDF export is configured to use Serenity reporting service and requires report template registration."
            }
        };
    }

    private static string BuildLeaveHistorySql(LeaveReportFilterRequest request)
    {
        return @"
            SELECT
                l.LeaveApplicationNo,
                (e.FirstName + ' ' + e.LastName) AS EmployeeName,
                d.DepartmentName,
                lt.LeaveTypeName,
                l.StartDate,
                l.EndDate,
                ISNULL(l.TotalDays, 0) AS TotalDays,
                ISNULL(l.PaidDays, 0) AS PaidDays,
                ISNULL(l.UnpaidDays, 0) AS UnpaidDays,
                ISNULL(l.FinalStatus, 0) AS FinalStatus
            FROM Leaves l
            INNER JOIN Employees e ON e.EmployeeId = l.EmployeeId
            LEFT JOIN Departments d ON d.DepartmentId = e.DepartmentId
            LEFT JOIN LeaveTypes lt ON lt.LeaveTypeId = l.LeaveTypeId
            WHERE (@EmployeeId IS NULL OR e.EmployeeId = @EmployeeId)
              AND (@DepartmentId IS NULL OR e.DepartmentId = @DepartmentId)
              AND (@LeaveTypeId IS NULL OR l.LeaveTypeId = @LeaveTypeId)
              AND (@DateFrom IS NULL OR l.StartDate >= @DateFrom)
              AND (@DateTo IS NULL OR l.EndDate <= @DateTo)
            ORDER BY l.ApplicationDate DESC, l.LeaveId DESC
        ";
    }

    private static object BuildParams(LeaveReportFilterRequest request)
    {
        return new
        {
            request.EmployeeId,
            request.DepartmentId,
            request.LeaveTypeId,
            request.DateFrom,
            request.DateTo
        };
    }
}
