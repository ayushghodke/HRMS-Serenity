using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = HRMS.Operations.LeaveRow;

namespace HRMS.Operations.Endpoints;

[Route("Services/Operations/Leave/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class LeaveEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ILeaveSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ILeaveSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] ILeaveDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] ILeaveRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] ILeaveListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] ILeaveListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.LeaveColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "LeaveList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse Approve(IUnitOfWork uow, [FromBody] int leaveId,
        [FromServices] IUserAccessor userAccessor)
    {
        var userId = int.Parse(userAccessor.User?.GetIdentifier() ?? "0");
        
        var row = uow.Connection.TryFirst<MyRow>(MyRow.Fields.LeaveId == leaveId);
        if (row == null)
            throw new ValidationError("LeaveNotFound", "Leave request not found.");

        if (row.FinalStatus == LeaveFinalStatus.Approved || row.FinalStatus == LeaveFinalStatus.Rejected || row.FinalStatus == LeaveFinalStatus.Cancelled)
            throw new ValidationError("InvalidStatus", "This leave request is already finalized.");

        if (row.FinalStatus == LeaveFinalStatus.Pending)
        {
            uow.Connection.UpdateById(new MyRow
            {
                LeaveId = leaveId,
                FinalStatus = LeaveFinalStatus.ManagerApproved,
                Status = LeaveStatus.Pending
            });

            uow.Connection.Insert(new LeaveApprovalRow
            {
                LeaveId = leaveId,
                ApproverId = userId,
                ApprovalLevel = 1,
                ApprovalDate = DateTime.Now,
                Status = LeaveStatus.Approved,
                TimeStamp = DateTime.Now
            });
        }
        else
        {
            uow.Connection.UpdateById(new MyRow
            {
                LeaveId = leaveId,
                Status = LeaveStatus.Approved,
                HrApprovalStatus = Operations.HrApprovalStatus.Approved,
                FinalStatus = LeaveFinalStatus.Approved,
                ApprovedBy = userId,
                ApprovedDate = DateTime.Now
            });

            uow.Connection.Insert(new LeaveApprovalRow
            {
                LeaveId = leaveId,
                ApproverId = userId,
                ApprovalLevel = 2,
                ApprovalDate = DateTime.Now,
                Status = LeaveStatus.Approved,
                TimeStamp = DateTime.Now
            });
        }

        return new ServiceResponse();
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse Reject(IUnitOfWork uow, [FromBody] int leaveId,
        [FromServices] IUserAccessor userAccessor)
    {
        var userId = int.Parse(userAccessor.User?.GetIdentifier() ?? "0");
        
        var row = uow.Connection.TryFirst<MyRow>(MyRow.Fields.LeaveId == leaveId);
        if (row == null)
            throw new ValidationError("LeaveNotFound", "Leave request not found.");

        if (row.FinalStatus == LeaveFinalStatus.Approved || row.FinalStatus == LeaveFinalStatus.Rejected || row.FinalStatus == LeaveFinalStatus.Cancelled)
            throw new ValidationError("InvalidStatus", "This leave request is already finalized.");

        uow.Connection.UpdateById(new MyRow
        {
            LeaveId = leaveId,
            Status = LeaveStatus.Rejected,
            HrApprovalStatus = Operations.HrApprovalStatus.Rejected,
            FinalStatus = LeaveFinalStatus.Rejected,
            ApprovedBy = userId,
            ApprovedDate = DateTime.Now
        });

        uow.Connection.Insert(new LeaveApprovalRow
        {
            LeaveId = leaveId,
            ApproverId = userId,
            ApprovalLevel = row.FinalStatus == LeaveFinalStatus.ManagerApproved ? 2 : 1,
            ApprovalDate = DateTime.Now,
            Status = LeaveStatus.Rejected,
            TimeStamp = DateTime.Now
        });

        return new ServiceResponse();
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse Cancel(IUnitOfWork uow, [FromBody] int leaveId,
        [FromServices] IUserAccessor userAccessor)
    {
        var userId = int.Parse(userAccessor.User?.GetIdentifier() ?? "0");

        var row = uow.Connection.TryFirst<MyRow>(MyRow.Fields.LeaveId == leaveId);
        if (row == null)
            throw new ValidationError("LeaveNotFound", "Leave request not found.");

        if (row.FinalStatus == LeaveFinalStatus.Approved || row.FinalStatus == LeaveFinalStatus.Rejected || row.FinalStatus == LeaveFinalStatus.Cancelled)
            throw new ValidationError("InvalidStatus", "This leave request is already finalized.");

        uow.Connection.UpdateById(new MyRow
        {
            LeaveId = leaveId,
            Status = LeaveStatus.Cancelled,
            FinalStatus = LeaveFinalStatus.Cancelled,
            ApprovedBy = userId,
            ApprovedDate = DateTime.Now
        });

        uow.Connection.Insert(new LeaveApprovalRow
        {
            LeaveId = leaveId,
            ApproverId = userId,
            ApprovalLevel = row.FinalStatus == LeaveFinalStatus.ManagerApproved ? 2 : 1,
            ApprovalDate = DateTime.Now,
            Status = LeaveStatus.Cancelled,
            TimeStamp = DateTime.Now
        });

        return new ServiceResponse();
    }
}
