using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HRMS.Operations.Endpoints;

[Route("Services/Operations/LeaveDashboard/[action]")]
[ConnectionKey(typeof(LeaveRow)), ServiceAuthorize(typeof(LeaveRow))]
public class LeaveDashboardEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public LeaveDashboardStatsResponse GetStats(IDbConnection connection, LeaveDashboardFilterRequest request)
    {
        var where = BuildWhere(request);

        var sql = $@"
            SELECT
                ISNULL(SUM(ISNULL(lp.OpeningBalance, 0) + ISNULL(lp.AccruedLeave, 0) + ISNULL(lp.CarryForwardLeave, 0)), 0) AS TotalAllocated,
                ISNULL(SUM(ISNULL(lp.UsedLeave, 0)), 0) AS LeaveTaken,
                ISNULL(SUM(ISNULL(lp.PendingLeave, 0)), 0) AS PendingApproval,
                ISNULL(SUM((ISNULL(lp.OpeningBalance, 0) + ISNULL(lp.AccruedLeave, 0) + ISNULL(lp.CarryForwardLeave, 0)) - ISNULL(lp.UsedLeave, 0)), 0) AS RemainingBalance,
                ISNULL(SUM(ISNULL(lp.LOPDays, 0)), 0) AS LOPDays
            FROM EmployeeLeaveProfiles lp
            INNER JOIN Employees e ON e.EmployeeId = lp.EmployeeId
            LEFT JOIN Departments d ON d.DepartmentId = e.DepartmentId
            WHERE 1 = 1 {where}
        ";

        var stats = connection.Query<LeaveDashboardStatsResponse>(sql, new
        {
            request.Branch,
            request.DepartmentId,
            request.EmployeeId,
            request.LeaveTypeId
        }).FirstOrDefault() ?? new LeaveDashboardStatsResponse();

        var todaySql = @"
            SELECT COUNT(*)
            FROM Leaves l
            INNER JOIN Employees e ON e.EmployeeId = l.EmployeeId
            LEFT JOIN Departments d ON d.DepartmentId = e.DepartmentId
            WHERE CAST(GETDATE() AS DATE) BETWEEN CAST(l.StartDate AS DATE) AND CAST(l.EndDate AS DATE)
              AND l.FinalStatus IN (1, 2)
        " + where;

        stats.EmployeesOnLeaveToday = connection.Query<int>(todaySql, new
        {
            request.Branch,
            request.DepartmentId,
            request.EmployeeId,
            request.LeaveTypeId
        }).FirstOrDefault();

        var upcomingSql = @"
            SELECT COUNT(*)
            FROM Leaves l
            INNER JOIN Employees e ON e.EmployeeId = l.EmployeeId
            LEFT JOIN Departments d ON d.DepartmentId = e.DepartmentId
            WHERE CAST(l.StartDate AS DATE) > CAST(GETDATE() AS DATE)
              AND CAST(l.StartDate AS DATE) <= DATEADD(DAY, 7, CAST(GETDATE() AS DATE))
              AND l.FinalStatus IN (0, 1, 2)
        " + where;

        stats.UpcomingLeaves = connection.Query<int>(upcomingSql, new
        {
            request.Branch,
            request.DepartmentId,
            request.EmployeeId,
            request.LeaveTypeId
        }).FirstOrDefault();

        return stats;
    }

    [HttpPost, AuthorizeList(typeof(LeaveRow))]
    public LeaveTrendResponse GetMonthlyTrend(IDbConnection connection, LeaveDashboardFilterRequest request)
    {
        var where = BuildWhere(request, tableAlias: "l");
        var sql = $@"
            SELECT FORMAT(CAST(l.StartDate AS DATE), 'MMM yyyy') AS Label,
                   ISNULL(SUM(ISNULL(l.TotalDays, 0)), 0) AS Value
            FROM Leaves l
            INNER JOIN Employees e ON e.EmployeeId = l.EmployeeId
            LEFT JOIN Departments d ON d.DepartmentId = e.DepartmentId
            WHERE l.StartDate >= DATEADD(MONTH, -11, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
              AND l.FinalStatus IN (1, 2)
              {where}
            GROUP BY YEAR(l.StartDate), MONTH(l.StartDate), FORMAT(CAST(l.StartDate AS DATE), 'MMM yyyy')
            ORDER BY YEAR(l.StartDate), MONTH(l.StartDate)
        ";

        var rows = connection.Query<(string Label, decimal Value)>(sql, new
        {
            request.Branch,
            request.DepartmentId,
            request.EmployeeId,
            request.LeaveTypeId
        });

        var response = new LeaveTrendResponse();
        foreach (var row in rows)
        {
            response.Labels.Add(row.Label);
            response.Values.Add(row.Value);
        }

        return response;
    }

    private static string BuildWhere(LeaveDashboardFilterRequest request, string tableAlias = "lp")
    {
        var leaveTypeColumn = tableAlias == "lp" ? "lp.LeaveTypeId" : "l.LeaveTypeId";
        return $@"
            AND (@Branch IS NULL OR @Branch = '' OR e.EmployeeCode IS NOT NULL)
            AND (@DepartmentId IS NULL OR e.DepartmentId = @DepartmentId)
            AND (@EmployeeId IS NULL OR e.EmployeeId = @EmployeeId)
            AND (@LeaveTypeId IS NULL OR {leaveTypeColumn} = @LeaveTypeId)
        ";
    }
}

public class LeaveDashboardFilterRequest : ServiceRequest
{
    public string Branch { get; set; }
    public int? DepartmentId { get; set; }
    public int? EmployeeId { get; set; }
    public int? LeaveTypeId { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
}

public class LeaveDashboardStatsResponse : ServiceResponse
{
    public decimal TotalAllocated { get; set; }
    public decimal LeaveTaken { get; set; }
    public decimal PendingApproval { get; set; }
    public decimal RemainingBalance { get; set; }
    public decimal LOPDays { get; set; }
    public int UpcomingLeaves { get; set; }
    public int EmployeesOnLeaveToday { get; set; }
}

public class LeaveTrendResponse : ServiceResponse
{
    public List<string> Labels { get; set; } = new();
    public List<decimal> Values { get; set; } = new();
}
