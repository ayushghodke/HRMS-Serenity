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
    const string jLeaveType = nameof(jLeaveType);
    const string jReportingManager = nameof(jReportingManager);
    const string jSubstituteEmployee = nameof(jSubstituteEmployee);
    const string jCreatedBy = nameof(jCreatedBy);

    [DisplayName("Leave Id"), Identity, IdProperty]
    public int? LeaveId { get => fields.LeaveId[this]; set => fields.LeaveId[this] = value; }

    [DisplayName("Employee"), NotNull, ForeignKey(typeof(EmployeeRow)), LeftJoin(jEmployee), TextualField(nameof(EmployeeFullName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? EmployeeId { get => fields.EmployeeId[this]; set => fields.EmployeeId[this] = value; }

    [DisplayName("Leave Type"), NotNull, DefaultValue(Operations.LeaveType.PaidLeave)]
    public LeaveType? LeaveType { get => (LeaveType?)fields.LeaveType[this]; set => fields.LeaveType[this] = (int?)value; }

    [DisplayName("Leave Type Master"), ForeignKey(typeof(LeaveTypeRow)), LeftJoin(jLeaveType), TextualField(nameof(LeaveTypeName))]
    [LookupEditor(typeof(LeaveTypeRow), Async = true)]
    public int? LeaveTypeId { get => fields.LeaveTypeId[this]; set => fields.LeaveTypeId[this] = value; }

    [DisplayName("Leave Application No"), Size(30)]
    public string LeaveApplicationNo { get => fields.LeaveApplicationNo[this]; set => fields.LeaveApplicationNo[this] = value; }

    [DisplayName("Application Date"), NotNull]
    public DateTime? ApplicationDate { get => fields.ApplicationDate[this]; set => fields.ApplicationDate[this] = value; }

    [DisplayName("Start Date"), NotNull]
    public DateTime? StartDate { get => fields.StartDate[this]; set => fields.StartDate[this] = value; }

    [DisplayName("End Date"), NotNull]
    public DateTime? EndDate { get => fields.EndDate[this]; set => fields.EndDate[this] = value; }

    [DisplayName("Half Day")]
    public HalfDaySession? HalfDaySession { get => (HalfDaySession?)fields.HalfDaySession[this]; set => fields.HalfDaySession[this] = (int?)value; }

    [DisplayName("Total Days"), NotNull] // Note: In a real app, might be calculated, but saving it is fine for now
    public double? TotalDays { get => fields.TotalDays[this]; set => fields.TotalDays[this] = value; }

    [DisplayName("Paid Days"), NotNull, DefaultValue(0)]
    public decimal? PaidDays { get => fields.PaidDays[this]; set => fields.PaidDays[this] = value; }

    [DisplayName("Unpaid Days"), NotNull, DefaultValue(0)]
    public decimal? UnpaidDays { get => fields.UnpaidDays[this]; set => fields.UnpaidDays[this] = value; }

    [DisplayName("Reason"), Size(500), NotNull, QuickSearch, NameProperty]
    public string Reason { get => fields.Reason[this]; set => fields.Reason[this] = value; }

    [DisplayName("Attachment"), Size(500), FileUploadEditor(FilenameFormat = "LeaveAttachments/~", CopyToHistory = true)]
    public string Attachment { get => fields.Attachment[this]; set => fields.Attachment[this] = value; }

    [DisplayName("Reporting Manager"), ForeignKey(typeof(EmployeeRow)), LeftJoin(jReportingManager), TextualField(nameof(ReportingManagerName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? ReportingManagerId { get => fields.ReportingManagerId[this]; set => fields.ReportingManagerId[this] = value; }

    [DisplayName("Status"), NotNull, DefaultValue(0)]
    public LeaveStatus? Status { get => (LeaveStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("HR Approval"), NotNull, DefaultValue(Operations.HrApprovalStatus.Pending)]
    public HrApprovalStatus? HrApprovalStatus { get => (HrApprovalStatus?)fields.HrApprovalStatus[this]; set => fields.HrApprovalStatus[this] = (int?)value; }

    [DisplayName("Final Status"), NotNull, DefaultValue(LeaveFinalStatus.Pending)]
    public LeaveFinalStatus? FinalStatus { get => (LeaveFinalStatus?)fields.FinalStatus[this]; set => fields.FinalStatus[this] = (int?)value; }

    [DisplayName("Manager Remarks"), Size(2000)]
    public string ManagerRemarks { get => fields.ManagerRemarks[this]; set => fields.ManagerRemarks[this] = value; }

    [DisplayName("HR Remarks"), Size(2000)]
    public string HrRemarks { get => fields.HrRemarks[this]; set => fields.HrRemarks[this] = value; }

    [DisplayName("Substitute Employee"), ForeignKey(typeof(EmployeeRow)), LeftJoin(jSubstituteEmployee), TextualField(nameof(SubstituteEmployeeName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? SubstituteEmployeeId { get => fields.SubstituteEmployeeId[this]; set => fields.SubstituteEmployeeId[this] = value; }

    [DisplayName("Contact During Leave"), Size(200)]
    public string ContactDuringLeave { get => fields.ContactDuringLeave[this]; set => fields.ContactDuringLeave[this] = value; }

    [DisplayName("Created By"), ForeignKey(typeof(UserRow)), LeftJoin(jCreatedBy), TextualField(nameof(CreatedByUsername))]
    [LookupEditor(typeof(UserRow), Async = true)]
    public int? CreatedByUserId { get => fields.CreatedByUserId[this]; set => fields.CreatedByUserId[this] = value; }

    [DisplayName("Approved By"), ForeignKey(typeof(UserRow)), LeftJoin(jApprovedBy), TextualField(nameof(ApprovedByUsername))]
    [LookupEditor(typeof(UserRow), Async = true)]
    public int? ApprovedBy { get => fields.ApprovedBy[this]; set => fields.ApprovedBy[this] = value; }

    [DisplayName("Created Date"), NotNull, Insertable(false), Updatable(false)]
    public DateTime? CreatedDate { get => fields.CreatedDate[this]; set => fields.CreatedDate[this] = value; }

    [DisplayName("Approved Date")]
    public DateTime? ApprovedDate { get => fields.ApprovedDate[this]; set => fields.ApprovedDate[this] = value; }

    [DisplayName("Employee Name"), Origin(jEmployee, nameof(EmployeeRow.FullName))]
    public string EmployeeFullName { get => fields.EmployeeFullName[this]; set => fields.EmployeeFullName[this] = value; }

    [DisplayName("Approved By"), Origin(jApprovedBy, nameof(UserRow.Username))]
    public string ApprovedByUsername { get => fields.ApprovedByUsername[this]; set => fields.ApprovedByUsername[this] = value; }

    [DisplayName("Leave Type Name"), Origin(jLeaveType, nameof(LeaveTypeRow.LeaveTypeName))]
    public string LeaveTypeName { get => fields.LeaveTypeName[this]; set => fields.LeaveTypeName[this] = value; }

    [DisplayName("Reporting Manager"), Origin(jReportingManager, nameof(EmployeeRow.FullName))]
    public string ReportingManagerName { get => fields.ReportingManagerName[this]; set => fields.ReportingManagerName[this] = value; }

    [DisplayName("Substitute Employee"), Origin(jSubstituteEmployee, nameof(EmployeeRow.FullName))]
    public string SubstituteEmployeeName { get => fields.SubstituteEmployeeName[this]; set => fields.SubstituteEmployeeName[this] = value; }

    [DisplayName("Created By"), Origin(jCreatedBy, nameof(UserRow.Username))]
    public string CreatedByUsername { get => fields.CreatedByUsername[this]; set => fields.CreatedByUsername[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field LeaveId;
        public Int32Field EmployeeId;
        public Int32Field LeaveType;
        public Int32Field LeaveTypeId;
        public StringField LeaveApplicationNo;
        public DateTimeField ApplicationDate;
        public DateTimeField StartDate;
        public DateTimeField EndDate;
        public Int32Field HalfDaySession;
        public DoubleField TotalDays;
        public DecimalField PaidDays;
        public DecimalField UnpaidDays;
        public StringField Reason;
        public StringField Attachment;
        public Int32Field ReportingManagerId;
        public Int32Field Status;
        public Int32Field HrApprovalStatus;
        public Int32Field FinalStatus;
        public StringField ManagerRemarks;
        public StringField HrRemarks;
        public Int32Field SubstituteEmployeeId;
        public StringField ContactDuringLeave;
        public Int32Field CreatedByUserId;
        public Int32Field ApprovedBy;
        public DateTimeField CreatedDate;
        public DateTimeField ApprovedDate;

        public StringField EmployeeFullName;
        public StringField ApprovedByUsername;
        public StringField LeaveTypeName;
        public StringField ReportingManagerName;
        public StringField SubstituteEmployeeName;
        public StringField CreatedByUsername;
    }
}

public enum LeaveType
{
    [Description("Paid Leave")]
    PaidLeave = 1,
    
    [Description("Unpaid Leave")]
    Unpaid = 2
}

public enum LeaveStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = -1,
    Cancelled = -2
}

public enum HalfDaySession
{
    [Description("First Half")]
    FirstHalf = 1,
    [Description("Second Half")]
    SecondHalf = 2
}

public enum HrApprovalStatus
{
    [Description("Pending")]
    Pending = 0,
    [Description("Approved")]
    Approved = 1,
    [Description("Rejected")]
    Rejected = -1
}

public enum LeaveFinalStatus
{
    [Description("Pending")]
    Pending = 0,
    [Description("Manager Approved")]
    ManagerApproved = 1,
    [Description("Approved")]
    Approved = 2,
    [Description("Rejected")]
    Rejected = -1,
    [Description("Cancelled")]
    Cancelled = -2
}
