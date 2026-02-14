using Serenity.ComponentModel;
using Serenity.Services;

namespace HRMS.Operations;

public class LeaveReportFilterRequest : ServiceRequest
{
    public int? EmployeeId { get; set; }
    public int? DepartmentId { get; set; }
    public int? LeaveTypeId { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
}

public class LeaveReportRow
{
    [DisplayName("Application No")]
    public string LeaveApplicationNo { get; set; }
    [DisplayName("Employee")]
    public string EmployeeName { get; set; }
    [DisplayName("Department")]
    public string DepartmentName { get; set; }
    [DisplayName("Leave Type")]
    public string LeaveTypeName { get; set; }
    [DisplayName("From")]
    public DateTime? StartDate { get; set; }
    [DisplayName("To")]
    public DateTime? EndDate { get; set; }
    [DisplayName("Total Days")]
    public decimal TotalDays { get; set; }
    [DisplayName("Paid Days")]
    public decimal PaidDays { get; set; }
    [DisplayName("Unpaid Days")]
    public decimal UnpaidDays { get; set; }
    [DisplayName("Final Status")]
    public int FinalStatus { get; set; }
}

public class DepartmentLeaveSummaryRow
{
    [DisplayName("Department")]
    public string DepartmentName { get; set; }
    [DisplayName("Total Leaves")]
    public decimal TotalLeaves { get; set; }
    [DisplayName("Paid Days")]
    public decimal PaidDays { get; set; }
    [DisplayName("Unpaid Days")]
    public decimal UnpaidDays { get; set; }
    [DisplayName("Pending")]
    public int PendingCount { get; set; }
}

public class MonthlyLeaveSummaryRow
{
    [DisplayName("Month")]
    public string MonthLabel { get; set; }
    [DisplayName("Total Leaves")]
    public decimal TotalLeaves { get; set; }
    [DisplayName("Paid Days")]
    public decimal PaidDays { get; set; }
    [DisplayName("Unpaid Days")]
    public decimal UnpaidDays { get; set; }
}

public class LeaveReportPdfRequest : ServiceRequest
{
    public string ReportType { get; set; }
    public LeaveReportFilterRequest Filter { get; set; }
}
