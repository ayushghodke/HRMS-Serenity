using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("LeaveTypes")]
[DisplayName("Leave Types"), InstanceName("Leave Type")]
[ReadPermission("Operations:Leave")]
[ModifyPermission("Operations:Leave")]
[LookupScript]
public sealed class LeaveTypeRow : Row<LeaveTypeRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Leave Type Id"), Identity, IdProperty]
    public int? LeaveTypeId { get => fields.LeaveTypeId[this]; set => fields.LeaveTypeId[this] = value; }

    [DisplayName("Leave Type Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string LeaveTypeName { get => fields.LeaveTypeName[this]; set => fields.LeaveTypeName[this] = value; }

    [DisplayName("Leave Code"), Size(20), NotNull]
    public string LeaveCode { get => fields.LeaveCode[this]; set => fields.LeaveCode[this] = value; }

    [DisplayName("Leave Category"), NotNull, DefaultValue(Operations.LeaveCategory.Paid)]
    public LeaveCategory? LeaveCategory { get => (LeaveCategory?)fields.LeaveCategory[this]; set => fields.LeaveCategory[this] = (int?)value; }

    [DisplayName("Annual Allocation"), NotNull, Scale(2)]
    public decimal? AnnualAllocation { get => fields.AnnualAllocation[this]; set => fields.AnnualAllocation[this] = value; }

    [DisplayName("Monthly Accrual"), NotNull]
    public bool? MonthlyAccrual { get => fields.MonthlyAccrual[this]; set => fields.MonthlyAccrual[this] = value; }

    [DisplayName("Carry Forward Allowed"), NotNull]
    public bool? CarryForwardAllowed { get => fields.CarryForwardAllowed[this]; set => fields.CarryForwardAllowed[this] = value; }

    [DisplayName("Max Carry Forward Days"), NotNull, Scale(2)]
    public decimal? MaxCarryForwardDays { get => fields.MaxCarryForwardDays[this]; set => fields.MaxCarryForwardDays[this] = value; }

    [DisplayName("Encashment Allowed"), NotNull]
    public bool? EncashmentAllowed { get => fields.EncashmentAllowed[this]; set => fields.EncashmentAllowed[this] = value; }

    [DisplayName("Applicable Departments"), Size(2000)]
    public string ApplicableDepartments { get => fields.ApplicableDepartments[this]; set => fields.ApplicableDepartments[this] = value; }

    [DisplayName("Applicable Designations"), Size(2000)]
    public string ApplicableDesignations { get => fields.ApplicableDesignations[this]; set => fields.ApplicableDesignations[this] = value; }

    [DisplayName("Applicable Branches"), Size(1000)]
    public string ApplicableBranches { get => fields.ApplicableBranches[this]; set => fields.ApplicableBranches[this] = value; }

    [DisplayName("Gender Specific"), NotNull]
    public bool? GenderSpecific { get => fields.GenderSpecific[this]; set => fields.GenderSpecific[this] = value; }

    [DisplayName("Probation Applicable"), NotNull]
    public bool? ProbationApplicable { get => fields.ProbationApplicable[this]; set => fields.ProbationApplicable[this] = value; }

    [DisplayName("Minimum Service Required (Months)"), NotNull]
    public int? MinimumServiceRequiredMonths { get => fields.MinimumServiceRequiredMonths[this]; set => fields.MinimumServiceRequiredMonths[this] = value; }

    [DisplayName("Max Leave Per Request"), NotNull, Scale(2)]
    public decimal? MaxLeavePerRequest { get => fields.MaxLeavePerRequest[this]; set => fields.MaxLeavePerRequest[this] = value; }

    [DisplayName("Sandwich Rule Applicable"), NotNull]
    public bool? SandwichRuleApplicable { get => fields.SandwichRuleApplicable[this]; set => fields.SandwichRuleApplicable[this] = value; }

    [DisplayName("Half Day Allowed"), NotNull]
    public bool? HalfDayAllowed { get => fields.HalfDayAllowed[this]; set => fields.HalfDayAllowed[this] = value; }

    [DisplayName("Documents Required"), NotNull]
    public bool? DocumentsRequired { get => fields.DocumentsRequired[this]; set => fields.DocumentsRequired[this] = value; }

    [DisplayName("Status"), NotNull, DefaultValue(RecordStatus.Active)]
    public RecordStatus? Status { get => (RecordStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field LeaveTypeId;
        public StringField LeaveTypeName;
        public StringField LeaveCode;
        public Int32Field LeaveCategory;
        public DecimalField AnnualAllocation;
        public BooleanField MonthlyAccrual;
        public BooleanField CarryForwardAllowed;
        public DecimalField MaxCarryForwardDays;
        public BooleanField EncashmentAllowed;
        public StringField ApplicableDepartments;
        public StringField ApplicableDesignations;
        public StringField ApplicableBranches;
        public BooleanField GenderSpecific;
        public BooleanField ProbationApplicable;
        public Int32Field MinimumServiceRequiredMonths;
        public DecimalField MaxLeavePerRequest;
        public BooleanField SandwichRuleApplicable;
        public BooleanField HalfDayAllowed;
        public BooleanField DocumentsRequired;
        public Int32Field Status;
    }
}

public enum LeaveCategory
{
    [Description("Paid")]
    Paid = 1,
    [Description("Unpaid")]
    Unpaid = 2
}

public enum RecordStatus
{
    [Description("Inactive")]
    Inactive = 0,
    [Description("Active")]
    Active = 1
}
