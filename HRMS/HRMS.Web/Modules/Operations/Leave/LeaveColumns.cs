using Serenity.ComponentModel;
using System.ComponentModel;
using HRMS.HR;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.Leave")]
[BasedOnRow(typeof(LeaveRow), CheckNames = true)]
public class LeaveColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int LeaveId { get; set; }
    [EditLink]
    public string LeaveApplicationNo { get; set; }
    public DateTime ApplicationDate { get; set; }
    [EditLink]
    public string EmployeeFullName { get; set; }
    public string LeaveTypeName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public HalfDaySession HalfDaySession { get; set; }
    public double TotalDays { get; set; }
    public decimal PaidDays { get; set; }
    public decimal UnpaidDays { get; set; }
    public string Reason { get; set; }
    [Width(100), QuickFilter, AlignCenter]
    public LeaveStatus Status { get; set; }
    public HrApprovalStatus HrApprovalStatus { get; set; }
    public LeaveFinalStatus FinalStatus { get; set; }
    public string ReportingManagerName { get; set; }
    public string ApprovedByUsername { get; set; }
}
