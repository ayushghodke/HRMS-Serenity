using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.LeaveType")]
[BasedOnRow(typeof(LeaveTypeRow), CheckNames = true)]
public class LeaveTypeForm
{
    public string LeaveTypeName { get; set; }
    public string LeaveCode { get; set; }
    public LeaveCategory LeaveCategory { get; set; }
    public decimal AnnualAllocation { get; set; }
    public bool MonthlyAccrual { get; set; }
    public bool CarryForwardAllowed { get; set; }
    public decimal MaxCarryForwardDays { get; set; }
    public bool EncashmentAllowed { get; set; }
    [TextAreaEditor(Rows = 2)]
    public string ApplicableDepartments { get; set; }
    [TextAreaEditor(Rows = 2)]
    public string ApplicableDesignations { get; set; }
    public string ApplicableBranches { get; set; }
    public bool GenderSpecific { get; set; }
    public bool ProbationApplicable { get; set; }
    public int MinimumServiceRequiredMonths { get; set; }
    public decimal MaxLeavePerRequest { get; set; }
    public bool SandwichRuleApplicable { get; set; }
    public bool HalfDayAllowed { get; set; }
    public bool DocumentsRequired { get; set; }
    public RecordStatus Status { get; set; }
}
