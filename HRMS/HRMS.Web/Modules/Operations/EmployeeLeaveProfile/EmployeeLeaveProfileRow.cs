using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using HRMS.HR;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("EmployeeLeaveProfiles")]
[DisplayName("Employee Leave Profiles"), InstanceName("Employee Leave Profile")]
[ReadPermission("Operations:Leave")]
[ModifyPermission("Operations:Leave")]
public sealed class EmployeeLeaveProfileRow : Row<EmployeeLeaveProfileRow.RowFields>, IIdRow
{
    const string jEmployee = nameof(jEmployee);
    const string jPolicy = nameof(jPolicy);
    const string jLeaveType = nameof(jLeaveType);

    [DisplayName("Employee Leave Profile Id"), Identity, IdProperty]
    public int? EmployeeLeaveProfileId { get => fields.EmployeeLeaveProfileId[this]; set => fields.EmployeeLeaveProfileId[this] = value; }

    [DisplayName("Employee"), NotNull, ForeignKey(typeof(EmployeeRow)), LeftJoin(jEmployee), TextualField(nameof(EmployeeFullName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? EmployeeId { get => fields.EmployeeId[this]; set => fields.EmployeeId[this] = value; }

    [DisplayName("Leave Policy"), ForeignKey(typeof(LeavePolicyRow)), LeftJoin(jPolicy), TextualField(nameof(LeavePolicyName))]
    [LookupEditor(typeof(LeavePolicyRow), Async = true)]
    public int? LeavePolicyId { get => fields.LeavePolicyId[this]; set => fields.LeavePolicyId[this] = value; }

    [DisplayName("Leave Type"), NotNull, ForeignKey(typeof(LeaveTypeRow)), LeftJoin(jLeaveType), TextualField(nameof(LeaveTypeName))]
    [LookupEditor(typeof(LeaveTypeRow), Async = true)]
    public int? LeaveTypeId { get => fields.LeaveTypeId[this]; set => fields.LeaveTypeId[this] = value; }

    [DisplayName("Opening Balance"), NotNull, Scale(2)]
    public decimal? OpeningBalance { get => fields.OpeningBalance[this]; set => fields.OpeningBalance[this] = value; }

    [DisplayName("Accrued Leave"), NotNull, Scale(2)]
    public decimal? AccruedLeave { get => fields.AccruedLeave[this]; set => fields.AccruedLeave[this] = value; }

    [DisplayName("Used Leave"), NotNull, Scale(2)]
    public decimal? UsedLeave { get => fields.UsedLeave[this]; set => fields.UsedLeave[this] = value; }

    [DisplayName("Pending Leave"), NotNull, Scale(2)]
    public decimal? PendingLeave { get => fields.PendingLeave[this]; set => fields.PendingLeave[this] = value; }

    [DisplayName("Carry Forward Leave"), NotNull, Scale(2)]
    public decimal? CarryForwardLeave { get => fields.CarryForwardLeave[this]; set => fields.CarryForwardLeave[this] = value; }

    [DisplayName("LOP Days"), NotNull, Scale(2)]
    public decimal? LOPDays { get => fields.LOPDays[this]; set => fields.LOPDays[this] = value; }

    [DisplayName("Last Updated Date"), NotNull]
    public DateTime? LastUpdatedDate { get => fields.LastUpdatedDate[this]; set => fields.LastUpdatedDate[this] = value; }

    [DisplayName("Employee"), Expression($"{jEmployee}.[FirstName] + ' ' + {jEmployee}.[LastName]")]
    public string EmployeeFullName { get => fields.EmployeeFullName[this]; set => fields.EmployeeFullName[this] = value; }

    [DisplayName("Department"), Origin(jEmployee, nameof(EmployeeRow.DepartmentName))]
    public string DepartmentName { get => fields.DepartmentName[this]; set => fields.DepartmentName[this] = value; }

    [DisplayName("Designation"), Origin(jEmployee, nameof(EmployeeRow.DesignationName))]
    public string DesignationName { get => fields.DesignationName[this]; set => fields.DesignationName[this] = value; }

    [DisplayName("Policy"), Origin(jPolicy, nameof(LeavePolicyRow.PolicyName))]
    public string LeavePolicyName { get => fields.LeavePolicyName[this]; set => fields.LeavePolicyName[this] = value; }

    [DisplayName("Leave Type"), Origin(jLeaveType, nameof(LeaveTypeRow.LeaveTypeName))]
    public string LeaveTypeName { get => fields.LeaveTypeName[this]; set => fields.LeaveTypeName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field EmployeeLeaveProfileId;
        public Int32Field EmployeeId;
        public Int32Field LeavePolicyId;
        public Int32Field LeaveTypeId;
        public DecimalField OpeningBalance;
        public DecimalField AccruedLeave;
        public DecimalField UsedLeave;
        public DecimalField PendingLeave;
        public DecimalField CarryForwardLeave;
        public DecimalField LOPDays;
        public DateTimeField LastUpdatedDate;

        public StringField EmployeeFullName;
        public StringField DepartmentName;
        public StringField DesignationName;
        public StringField LeavePolicyName;
        public StringField LeaveTypeName;
    }
}
