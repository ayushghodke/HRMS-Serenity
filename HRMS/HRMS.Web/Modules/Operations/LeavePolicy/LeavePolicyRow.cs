using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using HRMS.HR;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("LeavePolicies")]
[DisplayName("Leave Policies"), InstanceName("Leave Policy")]
[ReadPermission("Operations:Leave")]
[ModifyPermission("Operations:Leave")]
[LookupScript]
public sealed class LeavePolicyRow : Row<LeavePolicyRow.RowFields>, IIdRow, INameRow
{
    const string jDepartment = nameof(jDepartment);

    [DisplayName("Leave Policy Id"), Identity, IdProperty]
    public int? LeavePolicyId { get => fields.LeavePolicyId[this]; set => fields.LeavePolicyId[this] = value; }

    [DisplayName("Policy Name"), Size(150), NotNull, QuickSearch, NameProperty]
    public string PolicyName { get => fields.PolicyName[this]; set => fields.PolicyName[this] = value; }

    [DisplayName("Applicable From Date"), NotNull]
    public DateTime? ApplicableFromDate { get => fields.ApplicableFromDate[this]; set => fields.ApplicableFromDate[this] = value; }

    [DisplayName("Branch"), Size(100)]
    public string Branch { get => fields.Branch[this]; set => fields.Branch[this] = value; }

    [DisplayName("Department"), ForeignKey(typeof(DepartmentRow)), LeftJoin(jDepartment), TextualField(nameof(DepartmentName))]
    [LookupEditor(typeof(DepartmentRow), Async = true)]
    public int? DepartmentId { get => fields.DepartmentId[this]; set => fields.DepartmentId[this] = value; }

    [DisplayName("Max Consecutive Leaves Allowed"), NotNull]
    public int? MaxConsecutiveLeavesAllowed { get => fields.MaxConsecutiveLeavesAllowed[this]; set => fields.MaxConsecutiveLeavesAllowed[this] = value; }

    [DisplayName("Notice Period Leave Allowed"), NotNull]
    public bool? NoticePeriodLeaveAllowed { get => fields.NoticePeriodLeaveAllowed[this]; set => fields.NoticePeriodLeaveAllowed[this] = value; }

    [DisplayName("Probation Leave Allowed"), NotNull]
    public bool? ProbationLeaveAllowed { get => fields.ProbationLeaveAllowed[this]; set => fields.ProbationLeaveAllowed[this] = value; }

    [DisplayName("Approval Levels"), NotNull, DefaultValue(ApprovalLevelMode.FixedTwoLevel)]
    public ApprovalLevelMode? ApprovalLevels { get => (ApprovalLevelMode?)fields.ApprovalLevels[this]; set => fields.ApprovalLevels[this] = (int?)value; }

    [DisplayName("HR Override Permission"), NotNull]
    public bool? HROverridePermission { get => fields.HROverridePermission[this]; set => fields.HROverridePermission[this] = value; }

    [DisplayName("Payroll Cutoff Day"), NotNull, DefaultValue(30)]
    public int? PayrollCutoffDay { get => fields.PayrollCutoffDay[this]; set => fields.PayrollCutoffDay[this] = value; }

    [DisplayName("Status"), NotNull, DefaultValue(RecordStatus.Active)]
    public RecordStatus? Status { get => (RecordStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Department"), Origin(jDepartment, nameof(DepartmentRow.DepartmentName))]
    public string DepartmentName { get => fields.DepartmentName[this]; set => fields.DepartmentName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field LeavePolicyId;
        public StringField PolicyName;
        public DateTimeField ApplicableFromDate;
        public StringField Branch;
        public Int32Field DepartmentId;
        public Int32Field MaxConsecutiveLeavesAllowed;
        public BooleanField NoticePeriodLeaveAllowed;
        public BooleanField ProbationLeaveAllowed;
        public Int32Field ApprovalLevels;
        public BooleanField HROverridePermission;
        public Int32Field PayrollCutoffDay;
        public Int32Field Status;

        public StringField DepartmentName;
    }
}

public enum ApprovalLevelMode
{
    [Description("Single")]
    Single = 1,
    [Description("Fixed Two-Level")]
    FixedTwoLevel = 2
}
