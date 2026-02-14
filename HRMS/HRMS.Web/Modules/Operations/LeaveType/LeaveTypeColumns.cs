using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.LeaveType")]
[BasedOnRow(typeof(LeaveTypeRow), CheckNames = true)]
public class LeaveTypeColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int LeaveTypeId { get; set; }
    [EditLink]
    public string LeaveTypeName { get; set; }
    public string LeaveCode { get; set; }
    public LeaveCategory LeaveCategory { get; set; }
    public decimal AnnualAllocation { get; set; }
    public bool MonthlyAccrual { get; set; }
    public bool CarryForwardAllowed { get; set; }
    public bool SandwichRuleApplicable { get; set; }
    public bool HalfDayAllowed { get; set; }
    public RecordStatus Status { get; set; }
}
