using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using HRMS.HR;
using HRMS.Administration;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("Leaves")]
[DisplayName("Leaves"), InstanceName("Leave")]
[ReadPermission("Operations:Leave")]
[ModifyPermission("Operations:Leave")]
[LookupScript]
public sealed class LeaveRow : Row<LeaveRow.RowFields>, IIdRow, INameRow
{
    const string jEmployee = nameof(jEmployee);
    const string jApprovedBy = nameof(jApprovedBy);

    [DisplayName("Leave Id"), Identity, IdProperty]
    public int? LeaveId { get => fields.LeaveId[this]; set => fields.LeaveId[this] = value; }

    [DisplayName("Employee"), NotNull, ForeignKey(typeof(EmployeeRow)), LeftJoin(jEmployee), TextualField(nameof(EmployeeFullName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? EmployeeId { get => fields.EmployeeId[this]; set => fields.EmployeeId[this] = value; }

    [DisplayName("Leave Type"), NotNull, DefaultValue(1)]
    public LeaveType? LeaveType { get => (LeaveType?)fields.LeaveType[this]; set => fields.LeaveType[this] = (int?)value; }

    [DisplayName("Start Date"), NotNull]
    public DateTime? StartDate { get => fields.StartDate[this]; set => fields.StartDate[this] = value; }

    [DisplayName("End Date"), NotNull]
    public DateTime? EndDate { get => fields.EndDate[this]; set => fields.EndDate[this] = value; }

    [DisplayName("Total Days"), NotNull] // Note: In a real app, might be calculated, but saving it is fine for now
    public double? TotalDays { get => fields.TotalDays[this]; set => fields.TotalDays[this] = value; }

    [DisplayName("Reason"), Size(500), NotNull, QuickSearch, NameProperty]
    public string Reason { get => fields.Reason[this]; set => fields.Reason[this] = value; }

    [DisplayName("Status"), NotNull, DefaultValue(0)]
    public LeaveStatus? Status { get => (LeaveStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Approved By"), ForeignKey(typeof(UserRow)), LeftJoin(jApprovedBy), TextualField(nameof(ApprovedByUsername))]
    [LookupEditor(typeof(UserRow), Async = true)]
    public int? ApprovedBy { get => fields.ApprovedBy[this]; set => fields.ApprovedBy[this] = value; }

    [DisplayName("Created Date"), NotNull, DefaultValue("now")]
    public DateTime? CreatedDate { get => fields.CreatedDate[this]; set => fields.CreatedDate[this] = value; }

    [DisplayName("Employee Name"), Origin(jEmployee, nameof(EmployeeRow.FullName))]
    public string EmployeeFullName { get => fields.EmployeeFullName[this]; set => fields.EmployeeFullName[this] = value; }

    [DisplayName("Approved By"), Origin(jApprovedBy, nameof(UserRow.Username))]
    public string ApprovedByUsername { get => fields.ApprovedByUsername[this]; set => fields.ApprovedByUsername[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field LeaveId;
        public Int32Field EmployeeId;
        public Int32Field LeaveType;
        public DateTimeField StartDate;
        public DateTimeField EndDate;
        public DoubleField TotalDays;
        public StringField Reason;
        public Int32Field Status;
        public Int32Field ApprovedBy;
        public DateTimeField CreatedDate;

        public StringField EmployeeFullName;
        public StringField ApprovedByUsername;
    }
}

public enum LeaveType
{
    Casual = 1,
    Sick = 2,
    Earned = 3,
    Unpaid = 4
}

public enum LeaveStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = -1,
    Cancelled = -2
}
