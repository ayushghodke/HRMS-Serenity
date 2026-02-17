using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using HRMS.HR;
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
    public ServiceResponse Approve(IUnitOfWork uow, [FromBody] LeaveActionRequest request,
        [FromServices] IUserAccessor userAccessor)
    {
        var leaveId = request?.LeaveId ?? 0;
        if (leaveId <= 0)
            throw new ValidationError("LeaveIdRequired", "A valid leave id is required.");

        var userId = GetCurrentUserId(userAccessor);
        var actorEmployeeId = GetEmployeeIdByUserId(uow.Connection, userId);
        var isHrOrAdmin = IsHrOrAdmin();

        var row = uow.Connection.TryFirst<MyRow>(MyRow.Fields.LeaveId == leaveId);
        if (row == null)
            throw new ValidationError("LeaveNotFound", "Leave request not found.");

        if (row.FinalStatus == LeaveFinalStatus.Approved || row.FinalStatus == LeaveFinalStatus.Rejected || row.FinalStatus == LeaveFinalStatus.Cancelled)
            throw new ValidationError("InvalidStatus", "This leave request is already finalized.");

        if (row.FinalStatus == LeaveFinalStatus.Pending)
        {
            if (!actorEmployeeId.HasValue || !IsManagerOfLeave(uow.Connection, row, actorEmployeeId.Value))
                throw new ValidationError("AccessDenied", "Only the reporting manager can do first-level approval.");

            uow.Connection.UpdateById(new MyRow
            {
                LeaveId = leaveId,
                FinalStatus = LeaveFinalStatus.ManagerApproved,
                Status = LeaveStatus.Pending,
                ManagerRemarks = NormalizeRemarks(request?.Remarks)
            });

            uow.Connection.Insert(new LeaveApprovalRow
            {
                LeaveId = leaveId,
                ApproverId = userId,
                ApprovalLevel = 1,
                ApprovalDate = DateTime.Now,
                Status = LeaveStatus.Approved,
                Remarks = NormalizeRemarks(request?.Remarks),
                TimeStamp = DateTime.Now
            });
        }
        else if (row.FinalStatus == LeaveFinalStatus.ManagerApproved)
        {
            if (!isHrOrAdmin)
                throw new ValidationError("AccessDenied", "Only HR/Admin can do final approval.");

            uow.Connection.UpdateById(new MyRow
            {
                LeaveId = leaveId,
                Status = LeaveStatus.Approved,
                HrApprovalStatus = Operations.HrApprovalStatus.Approved,
                FinalStatus = LeaveFinalStatus.Approved,
                HrRemarks = NormalizeRemarks(request?.Remarks),
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
                Remarks = NormalizeRemarks(request?.Remarks),
                TimeStamp = DateTime.Now
            });
        }
        else
        {
            throw new ValidationError("InvalidStatus", "This leave request is not in an approvable state.");
        }

        return new ServiceResponse();
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse Reject(IUnitOfWork uow, [FromBody] LeaveActionRequest request,
        [FromServices] IUserAccessor userAccessor)
    {
        var leaveId = request?.LeaveId ?? 0;
        if (leaveId <= 0)
            throw new ValidationError("LeaveIdRequired", "A valid leave id is required.");

        var remarks = RequireRemarks(request?.Remarks, "Rejection remarks are required.");
        var userId = GetCurrentUserId(userAccessor);
        var actorEmployeeId = GetEmployeeIdByUserId(uow.Connection, userId);
        var isHrOrAdmin = IsHrOrAdmin();

        var row = uow.Connection.TryFirst<MyRow>(MyRow.Fields.LeaveId == leaveId);
        if (row == null)
            throw new ValidationError("LeaveNotFound", "Leave request not found.");

        if (row.FinalStatus == LeaveFinalStatus.Approved || row.FinalStatus == LeaveFinalStatus.Rejected || row.FinalStatus == LeaveFinalStatus.Cancelled)
            throw new ValidationError("InvalidStatus", "This leave request is already finalized.");

        var isManagerStage = row.FinalStatus == LeaveFinalStatus.Pending;
        var approvalLevel = isManagerStage ? 1 : 2;

        if (isManagerStage)
        {
            if (!actorEmployeeId.HasValue || !IsManagerOfLeave(uow.Connection, row, actorEmployeeId.Value))
                throw new ValidationError("AccessDenied", "Only the reporting manager can reject at first level.");
        }
        else if (row.FinalStatus == LeaveFinalStatus.ManagerApproved)
        {
            if (!isHrOrAdmin)
                throw new ValidationError("AccessDenied", "Only HR/Admin can reject at final level.");
        }
        else
        {
            throw new ValidationError("InvalidStatus", "This leave request is not in a rejectable state.");
        }

        uow.Connection.UpdateById(new MyRow
        {
            LeaveId = leaveId,
            Status = LeaveStatus.Rejected,
            HrApprovalStatus = Operations.HrApprovalStatus.Rejected,
            FinalStatus = LeaveFinalStatus.Rejected,
            ManagerRemarks = isManagerStage ? remarks : row.ManagerRemarks,
            HrRemarks = !isManagerStage ? remarks : row.HrRemarks,
            ApprovedBy = userId,
            ApprovedDate = DateTime.Now
        });

        uow.Connection.Insert(new LeaveApprovalRow
        {
            LeaveId = leaveId,
            ApproverId = userId,
            ApprovalLevel = approvalLevel,
            ApprovalDate = DateTime.Now,
            Status = LeaveStatus.Rejected,
            Remarks = remarks,
            TimeStamp = DateTime.Now
        });

        return new ServiceResponse();
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public ServiceResponse Cancel(IUnitOfWork uow, [FromBody] LeaveActionRequest request,
        [FromServices] IUserAccessor userAccessor)
    {
        var leaveId = request?.LeaveId ?? 0;
        if (leaveId <= 0)
            throw new ValidationError("LeaveIdRequired", "A valid leave id is required.");

        var remarks = RequireRemarks(request?.Remarks, "Cancellation remarks are required.");
        var userId = GetCurrentUserId(userAccessor);
        var actorEmployeeId = GetEmployeeIdByUserId(uow.Connection, userId);

        var row = uow.Connection.TryFirst<MyRow>(MyRow.Fields.LeaveId == leaveId);
        if (row == null)
            throw new ValidationError("LeaveNotFound", "Leave request not found.");

        if (row.FinalStatus != LeaveFinalStatus.Pending)
            throw new ValidationError("InvalidStatus", "Only pending leave requests can be cancelled.");

        if (!actorEmployeeId.HasValue || !row.EmployeeId.HasValue || actorEmployeeId.Value != row.EmployeeId.Value)
            throw new ValidationError("AccessDenied", "Only the employee who requested the leave can cancel it.");

        uow.Connection.UpdateById(new MyRow
        {
            LeaveId = leaveId,
            Status = LeaveStatus.Cancelled,
            FinalStatus = LeaveFinalStatus.Cancelled,
            ManagerRemarks = remarks,
            ApprovedBy = userId,
            ApprovedDate = DateTime.Now
        });

        uow.Connection.Insert(new LeaveApprovalRow
        {
            LeaveId = leaveId,
            ApproverId = userId,
            ApprovalLevel = 0,
            ApprovalDate = DateTime.Now,
            Status = LeaveStatus.Cancelled,
            Remarks = remarks,
            TimeStamp = DateTime.Now
        });

        return new ServiceResponse();
    }

    private int GetCurrentUserId(IUserAccessor userAccessor)
    {
        if (!int.TryParse(userAccessor.User?.GetIdentifier(), out var userId) || userId <= 0)
            throw new ValidationError("AccessDenied", "Unable to resolve current user.");

        return userId;
    }

    private static string NormalizeRemarks(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }

    private static string RequireRemarks(string value, string message)
    {
        var remarks = NormalizeRemarks(value);
        if (string.IsNullOrEmpty(remarks))
            throw new ValidationError("RemarksRequired", message);

        return remarks;
    }

    private int? GetEmployeeIdByUserId(IDbConnection connection, int userId)
    {
        var employee = connection.TryFirst<EmployeeRow>(EmployeeRow.Fields.UserId == userId);
        return employee?.EmployeeId;
    }

    private bool IsManagerOfLeave(IDbConnection connection, MyRow leave, int actorEmployeeId)
    {
        if (leave.ReportingManagerId.HasValue && leave.ReportingManagerId.Value == actorEmployeeId)
            return true;

        if (!leave.EmployeeId.HasValue)
            return false;

        var employee = connection.TryById<EmployeeRow>(leave.EmployeeId.Value);
        return employee?.ManagerId == actorEmployeeId;
    }

    private bool IsHrOrAdmin()
    {
        return Permissions.HasPermission("HR:Employee") ||
               Permissions.HasPermission("Administration:Security");
    }
}

public class LeaveActionRequest : ServiceRequest
{
    public int LeaveId { get; set; }
    public string Remarks { get; set; }
}
