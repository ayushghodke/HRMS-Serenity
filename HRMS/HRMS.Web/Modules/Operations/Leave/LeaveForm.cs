using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.Leave")]
[BasedOnRow(typeof(LeaveRow), CheckNames = true)]
public class LeaveForm
{
    [ReadOnly(true)]
    public string LeaveApplicationNo { get; set; }
    [ReadOnly(true)]
    public DateTime ApplicationDate { get; set; }
    public int EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    [HalfWidth]
    public DateTime StartDate { get; set; }
    [HalfWidth]
    public DateTime EndDate { get; set; }
    public HalfDaySession HalfDaySession { get; set; }
    [ReadOnly(true)]
    public double TotalDays { get; set; }
    [ReadOnly(true)]
    public decimal PaidDays { get; set; }
    [ReadOnly(true)]
    public decimal UnpaidDays { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Reason { get; set; }
    public string Attachment { get; set; }
    public int ReportingManagerId { get; set; }
    [ReadOnly(true)]
    public LeaveStatus Status { get; set; }
    [ReadOnly(true)]
    public HrApprovalStatus HrApprovalStatus { get; set; }
    [ReadOnly(true)]
    public LeaveFinalStatus FinalStatus { get; set; }
    [TextAreaEditor(Rows = 2)]
    public string ManagerRemarks { get; set; }
    [TextAreaEditor(Rows = 2)]
    public string HrRemarks { get; set; }
    public int SubstituteEmployeeId { get; set; }
    public string ContactDuringLeave { get; set; }
}
