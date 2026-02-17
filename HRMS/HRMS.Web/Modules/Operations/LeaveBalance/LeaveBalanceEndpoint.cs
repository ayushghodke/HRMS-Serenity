using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = HRMS.Operations.LeaveBalanceRow;

namespace HRMS.Operations.Endpoints;

[Route("Services/Operations/LeaveBalance/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class LeaveBalanceEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ILeaveBalanceSaveHandler handler)
    {
        throw new ValidationError("ReadOnlyProjection", "Leave balances are derived from employee leave profiles and cannot be created manually.");
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ILeaveBalanceSaveHandler handler)
    {
        throw new ValidationError("ReadOnlyProjection", "Leave balances are derived from employee leave profiles and cannot be edited manually.");
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] ILeaveBalanceDeleteHandler handler)
    {
        throw new ValidationError("ReadOnlyProjection", "Leave balances are derived from employee leave profiles and cannot be deleted manually.");
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] ILeaveBalanceRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] ILeaveBalanceListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] ILeaveBalanceListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.LeaveBalanceColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "LeaveBalanceList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse RecalculateAllBalances(IUnitOfWork uow)
    {
        var currentYear = DateTime.Now.Year;

        var syncProfilesSql = @"
            ;WITH LeaveUsage AS
            (
                SELECT
                    l.EmployeeId,
                    l.LeaveTypeId,
                    SUM(CASE WHEN ISNULL(l.FinalStatus, 0) = 2 THEN ISNULL(l.PaidDays, 0) ELSE 0 END) AS UsedLeave,
                    SUM(CASE WHEN ISNULL(l.FinalStatus, 0) = 2 THEN ISNULL(l.UnpaidDays, 0) ELSE 0 END) AS LOPDays,
                    SUM(CASE WHEN ISNULL(l.FinalStatus, 0) IN (0, 1) THEN ISNULL(l.TotalDays, 0) ELSE 0 END) AS PendingLeave
                FROM Leaves l
                WHERE l.StartDate < DATEFROMPARTS(@CurrentYear + 1, 1, 1)
                  AND l.EndDate >= DATEFROMPARTS(@CurrentYear, 1, 1)
                  AND l.LeaveTypeId IS NOT NULL
                GROUP BY l.EmployeeId, l.LeaveTypeId
            )
            UPDATE ep
            SET
                ep.UsedLeave = ISNULL(lu.UsedLeave, 0),
                ep.PendingLeave = ISNULL(lu.PendingLeave, 0),
                ep.LOPDays = ISNULL(lu.LOPDays, 0),
                ep.LastUpdatedDate = GETDATE()
            FROM EmployeeLeaveProfiles ep
            LEFT JOIN LeaveUsage lu
                ON lu.EmployeeId = ep.EmployeeId
               AND lu.LeaveTypeId = ep.LeaveTypeId;
        ";

        uow.Connection.Execute(syncProfilesSql, new { CurrentYear = currentYear });

        var syncLegacyBalancesSql = @"
            ;WITH PaidSource AS
            (
                SELECT
                    ep.EmployeeId,
                    SUM(ISNULL(ep.OpeningBalance, 0) + ISNULL(ep.AccruedLeave, 0) + ISNULL(ep.CarryForwardLeave, 0)) AS Allocated,
                    SUM(ISNULL(ep.UsedLeave, 0)) AS Used
                FROM EmployeeLeaveProfiles ep
                INNER JOIN LeaveTypes lt ON lt.LeaveTypeId = ep.LeaveTypeId
                WHERE ISNULL(lt.LeaveCategory, 0) = 1
                GROUP BY ep.EmployeeId
            ),
            UnpaidSource AS
            (
                SELECT
                    ep.EmployeeId,
                    CAST(0 AS DECIMAL(18, 2)) AS Allocated,
                    SUM(ISNULL(ep.LOPDays, 0)) AS Used
                FROM EmployeeLeaveProfiles ep
                GROUP BY ep.EmployeeId
            ),
            SourceRows AS
            (
                SELECT EmployeeId, 1 AS LeaveType, Allocated, Used FROM PaidSource
                UNION ALL
                SELECT EmployeeId, 2 AS LeaveType, Allocated, Used FROM UnpaidSource
            )
            MERGE LeaveBalances AS tgt
            USING SourceRows AS src
                ON tgt.EmployeeId = src.EmployeeId
               AND tgt.LeaveType = src.LeaveType
               AND tgt.[Year] = @CurrentYear
            WHEN MATCHED THEN
                UPDATE SET tgt.Allocated = src.Allocated, tgt.Used = src.Used
            WHEN NOT MATCHED THEN
                INSERT (EmployeeId, LeaveType, [Year], Allocated, Used)
                VALUES (src.EmployeeId, src.LeaveType, @CurrentYear, src.Allocated, src.Used);
        ";

        uow.Connection.Execute(syncLegacyBalancesSql, new { CurrentYear = currentYear });

        return new SaveResponse();
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> GetEmployeeBalances(IDbConnection connection, [FromBody] int employeeId,
        [FromServices] ILeaveBalanceListHandler handler)
    {
        throw new ValidationError("DeprecatedEndpoint", "GetEmployeeBalances is deprecated. Use EmployeeLeaveProfile list APIs as the canonical balance source.");
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse RunYearEndProcessing(IUnitOfWork uow, YearEndProcessingRequest request)
    {
        var sourceYear = request.Year <= 0 ? DateTime.Now.Year : request.Year;
        var nextYear = sourceYear + 1;
        var carried = 0;

        var sql = @"
            SELECT
                lp.EmployeeId,
                lp.LeaveTypeId,
                ISNULL(lp.OpeningBalance, 0) AS OpeningBalance,
                ISNULL(lp.AccruedLeave, 0) AS AccruedLeave,
                ISNULL(lp.UsedLeave, 0) AS UsedLeave,
                ISNULL(lp.CarryForwardLeave, 0) AS CarryForwardLeave,
                ISNULL(lt.CarryForwardAllowed, 0) AS CarryForwardAllowed,
                ISNULL(lt.MaxCarryForwardDays, 0) AS MaxCarryForwardDays,
                ISNULL(lt.EncashmentAllowed, 0) AS EncashmentAllowed,
                ISNULL(lt.AnnualAllocation, 0) AS AnnualAllocation
            FROM EmployeeLeaveProfiles lp
            INNER JOIN LeaveTypes lt ON lt.LeaveTypeId = lp.LeaveTypeId
        ";

        var rows = uow.Connection.Query<YearEndCarryForwardRow>(sql).ToList();
        foreach (var row in rows)
        {
            var remaining = Math.Max(0m, row.OpeningBalance + row.AccruedLeave + row.CarryForwardLeave - row.UsedLeave);
            var carryForward = row.CarryForwardAllowed ? Math.Min(remaining, row.MaxCarryForwardDays) : 0m;

            var existingNext = uow.Connection.TryFirst<Operations.EmployeeLeaveProfileRow>(
                Operations.EmployeeLeaveProfileRow.Fields.EmployeeId == row.EmployeeId &
                Operations.EmployeeLeaveProfileRow.Fields.LeaveTypeId == row.LeaveTypeId);

            if (existingNext != null)
            {
                uow.Connection.UpdateById(new Operations.EmployeeLeaveProfileRow
                {
                    EmployeeLeaveProfileId = existingNext.EmployeeLeaveProfileId,
                    OpeningBalance = row.AnnualAllocation,
                    AccruedLeave = 0,
                    UsedLeave = 0,
                    PendingLeave = 0,
                    CarryForwardLeave = carryForward,
                    LOPDays = 0,
                    LastUpdatedDate = DateTime.Now
                });
            }

            carried++;
        }

        return new ServiceResponse();
    }
}

public class YearEndProcessingRequest : ServiceRequest
{
    public int Year { get; set; }
}

public class YearEndCarryForwardRow
{
    public int EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal AccruedLeave { get; set; }
    public decimal UsedLeave { get; set; }
    public decimal CarryForwardLeave { get; set; }
    public bool CarryForwardAllowed { get; set; }
    public decimal MaxCarryForwardDays { get; set; }
    public bool EncashmentAllowed { get; set; }
    public decimal AnnualAllocation { get; set; }
}
