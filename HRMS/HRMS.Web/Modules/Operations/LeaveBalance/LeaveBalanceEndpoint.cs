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
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ILeaveBalanceSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] ILeaveBalanceDeleteHandler handler)
    {
        return handler.Delete(uow, request);
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
        var employeeFld = HR.EmployeeRow.Fields;
        var balanceFld = MyRow.Fields;
        var leaveFld = Operations.LeaveRow.Fields;
        
        // Get all active employees
        var employees = uow.Connection.List<HR.EmployeeRow>(
            employeeFld.Status == (int)HR.EmployeeStatus.Active);
        
        int processed = 0;
        
        foreach (var employee in employees)
        {
            var usedPaid = 0m;
            var usedUnpaid = 0m;
            var leaves = uow.Connection.List<Operations.LeaveRow>(
                leaveFld.EmployeeId == employee.EmployeeId.Value &
                leaveFld.Status == (int)Operations.LeaveStatus.Approved);

            foreach (var leave in leaves)
            {
                var totalDays = (decimal)(leave.TotalDays ?? 0);
                usedPaid += leave.PaidDays ?? (leave.LeaveType == Operations.LeaveType.PaidLeave ? totalDays : 0m);
                usedUnpaid += leave.UnpaidDays ?? (leave.LeaveType == Operations.LeaveType.Unpaid ? totalDays : 0m);
            }

            var annualPaidAllocation = Math.Max(0, (employee.PaidLeavesPerMonth ?? 2) * 12);

            var existingPaidBalance = uow.Connection.TryFirst<MyRow>(
                balanceFld.EmployeeId == employee.EmployeeId.Value &
                balanceFld.LeaveType == (int)Operations.LeaveType.PaidLeave &
                balanceFld.Year == currentYear);

            if (existingPaidBalance != null)
            {
                uow.Connection.UpdateById(new MyRow
                {
                    LeaveBalanceId = existingPaidBalance.LeaveBalanceId,
                    Allocated = annualPaidAllocation,
                    Used = usedPaid
                });
            }
            else
            {
                uow.Connection.Insert(new MyRow
                {
                    EmployeeId = employee.EmployeeId.Value,
                    LeaveType = Operations.LeaveType.PaidLeave,
                    Year = currentYear,
                    Allocated = annualPaidAllocation,
                    Used = usedPaid
                });
            }

            var existingUnpaidBalance = uow.Connection.TryFirst<MyRow>(
                balanceFld.EmployeeId == employee.EmployeeId.Value &
                balanceFld.LeaveType == (int)Operations.LeaveType.Unpaid &
                balanceFld.Year == currentYear);

            if (existingUnpaidBalance != null)
            {
                uow.Connection.UpdateById(new MyRow
                {
                    LeaveBalanceId = existingUnpaidBalance.LeaveBalanceId,
                    Allocated = 0,
                    Used = usedUnpaid
                });
            }
            else
            {
                uow.Connection.Insert(new MyRow
                {
                    EmployeeId = employee.EmployeeId.Value,
                    LeaveType = Operations.LeaveType.Unpaid,
                    Year = currentYear,
                    Allocated = 0,
                    Used = usedUnpaid
                });
            }
            
            processed++;
        }
        
        // Return success (message will be shown in UI)
        return new SaveResponse();
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> GetEmployeeBalances(IDbConnection connection, [FromBody] int employeeId,
        [FromServices] ILeaveBalanceListHandler handler)
    {
        var currentYear = DateTime.Now.Year;
        var request = new ListRequest
        {
            Criteria = new Criteria(MyRow.Fields.EmployeeId.PropertyName) == employeeId & 
                       new Criteria(MyRow.Fields.Year.PropertyName) == currentYear
        };
        
        return handler.List(connection, request);
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
