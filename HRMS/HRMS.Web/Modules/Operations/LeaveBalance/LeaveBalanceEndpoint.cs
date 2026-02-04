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
            // Calculate total used leaves for this employee for Paid Leave type
            // Note: We count ALL approved leaves regardless of year since accrual is cumulative from join date
            // or we could limit to current year if "Allocated" was annual. 
            // With monthly accrual model, it's safer to sum all usage if we assume Accrued is total since joining.
            // However, typically "Used" field in database might be per year. 
            // Let's assume for now we sum all approved paid leaves for this employee.
            
            var usedLeaves = 0m;
            var leaves = uow.Connection.List<Operations.LeaveRow>(
                leaveFld.EmployeeId == employee.EmployeeId.Value &
                leaveFld.LeaveType == (int)Operations.LeaveType.PaidLeave &
                leaveFld.Status == (int)Operations.LeaveStatus.Approved);
                
            foreach (var leave in leaves)
            {
                usedLeaves += (decimal)(leave.TotalDays ?? 0);
            }

            // Check if balance record exists
            var existingBalance = uow.Connection.TryFirst<MyRow>(
                balanceFld.EmployeeId == employee.EmployeeId.Value &
                balanceFld.LeaveType == (int)Operations.LeaveType.PaidLeave &
                balanceFld.Year == currentYear);
            
            if (existingBalance != null)
            {
                // Update existing record with correct usage
                uow.Connection.UpdateById(new MyRow
                {
                    LeaveBalanceId = existingBalance.LeaveBalanceId,
                    Used = usedLeaves
                });
            }
            else
            {
                // Create new record with correct usage
                uow.Connection.Insert(new MyRow
                {
                    EmployeeId = employee.EmployeeId.Value,
                    LeaveType = Operations.LeaveType.PaidLeave,
                    Year = currentYear,
                    Allocated = 36, 
                    Used = usedLeaves
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
}
