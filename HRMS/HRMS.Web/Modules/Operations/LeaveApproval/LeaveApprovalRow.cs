using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using HRMS.Administration;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("LeaveApprovals")]
[DisplayName("Leave Approvals"), InstanceName("Leave Approval")]
[ReadPermission("Operations:Leave")]
[ModifyPermission("Operations:Leave")]
public sealed class LeaveApprovalRow : Row<LeaveApprovalRow.RowFields>, IIdRow
{
    const string jLeave = nameof(jLeave);
    const string jApprover = nameof(jApprover);
    const string jEscalation = nameof(jEscalation);

    [DisplayName("Approval Id"), Identity, IdProperty]
    public int? ApprovalId { get => fields.ApprovalId[this]; set => fields.ApprovalId[this] = value; }

    [DisplayName("Leave"), NotNull, ForeignKey(typeof(LeaveRow)), LeftJoin(jLeave), TextualField(nameof(LeaveApplicationNo))]
    [LookupEditor(typeof(LeaveRow), Async = true)]
    public int? LeaveId { get => fields.LeaveId[this]; set => fields.LeaveId[this] = value; }

    [DisplayName("Approver"), NotNull, ForeignKey(typeof(UserRow)), LeftJoin(jApprover), TextualField(nameof(ApproverUsername))]
    [LookupEditor(typeof(UserRow), Async = true)]
    public int? ApproverId { get => fields.ApproverId[this]; set => fields.ApproverId[this] = value; }

    [DisplayName("Approval Level"), NotNull]
    public int? ApprovalLevel { get => fields.ApprovalLevel[this]; set => fields.ApprovalLevel[this] = value; }

    [DisplayName("Approval Date"), NotNull]
    public DateTime? ApprovalDate { get => fields.ApprovalDate[this]; set => fields.ApprovalDate[this] = value; }

    [DisplayName("Status"), NotNull]
    public LeaveStatus? Status { get => (LeaveStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Remarks"), Size(2000)]
    public string Remarks { get => fields.Remarks[this]; set => fields.Remarks[this] = value; }

    [DisplayName("Escalation Trigger"), NotNull]
    public bool? EscalationTrigger { get => fields.EscalationTrigger[this]; set => fields.EscalationTrigger[this] = value; }

    [DisplayName("Escalation To"), ForeignKey(typeof(UserRow)), LeftJoin(jEscalation), TextualField(nameof(EscalationToUsername))]
    [LookupEditor(typeof(UserRow), Async = true)]
    public int? EscalationTo { get => fields.EscalationTo[this]; set => fields.EscalationTo[this] = value; }

    [DisplayName("Time Stamp"), NotNull]
    public DateTime? TimeStamp { get => fields.TimeStamp[this]; set => fields.TimeStamp[this] = value; }

    [DisplayName("Application No"), Origin(jLeave, nameof(LeaveRow.LeaveApplicationNo))]
    public string LeaveApplicationNo { get => fields.LeaveApplicationNo[this]; set => fields.LeaveApplicationNo[this] = value; }

    [DisplayName("Approver"), Origin(jApprover, nameof(UserRow.Username))]
    public string ApproverUsername { get => fields.ApproverUsername[this]; set => fields.ApproverUsername[this] = value; }

    [DisplayName("Escalation To"), Origin(jEscalation, nameof(UserRow.Username))]
    public string EscalationToUsername { get => fields.EscalationToUsername[this]; set => fields.EscalationToUsername[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field ApprovalId;
        public Int32Field LeaveId;
        public Int32Field ApproverId;
        public Int32Field ApprovalLevel;
        public DateTimeField ApprovalDate;
        public Int32Field Status;
        public StringField Remarks;
        public BooleanField EscalationTrigger;
        public Int32Field EscalationTo;
        public DateTimeField TimeStamp;

        public StringField LeaveApplicationNo;
        public StringField ApproverUsername;
        public StringField EscalationToUsername;
    }
}
