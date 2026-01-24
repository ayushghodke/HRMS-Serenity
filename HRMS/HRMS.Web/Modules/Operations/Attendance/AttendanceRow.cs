using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("Attendance")]
[DisplayName("Attendance"), InstanceName("Attendance")]
[ReadPermission("Operations:Attendance")]
[ModifyPermission("Operations:Attendance")]
[ServiceLookupPermission("Operations:Attendance")]
public sealed class AttendanceRow : Row<AttendanceRow.RowFields>, IIdRow, INameRow
{
    const string jName = nameof(jName);
    const string jApprovedBy = nameof(jApprovedBy);

    [DisplayName("Id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("User Id"), Size(100), NotNull, QuickSearch, NameProperty]
    public string UserId { get => fields.UserId[this]; set => fields.UserId[this] = value; }

    [DisplayName("Name"), NotNull, ForeignKey(typeof(Administration.UserRow)), LeftJoin(jName), TextualField(nameof(NameUsername))]
    [LookupEditor(typeof(Administration.UserRow), Async = true)]
    public int? Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Date N Time"), NotNull]
    public DateTime? DateNTime { get => fields.DateNTime[this]; set => fields.DateNTime[this] = value; }

    [DisplayName("Type"), NotNull, DefaultValue(AttendanceType.Present)]
    public AttendanceType? Type { get => (AttendanceType?)fields.Type[this]; set => fields.Type[this] = (int?)value; }

    [DisplayName("Coordinates"), Size(200), NotNull]
    public string Coordinates { get => fields.Coordinates[this]; set => fields.Coordinates[this] = value; }

    [DisplayName("Punch Out Coordinates"), Size(200)]
    public string PunchOutCoordinates { get => fields.PunchOutCoordinates[this]; set => fields.PunchOutCoordinates[this] = value; }

    [DisplayName("Location"), Size(2000), NotNull]
    public string Location { get => fields.Location[this]; set => fields.Location[this] = value; }

    [DisplayName("Approved By"), ForeignKey(typeof(Administration.UserRow)), LeftJoin(jApprovedBy)]
    [TextualField(nameof(ApprovedByUsername)), LookupEditor(typeof(Administration.UserRow), Async = true)]
    public int? ApprovedBy { get => fields.ApprovedBy[this]; set => fields.ApprovedBy[this] = value; }

    [DisplayName("Punch In"), NotNull]
    public DateTime? PunchIn { get => fields.PunchIn[this]; set => fields.PunchIn[this] = value; }

    [DisplayName("Punch Out")]
    public DateTime? PunchOut { get => fields.PunchOut[this]; set => fields.PunchOut[this] = value; }

    [DisplayName("Distance")]
    public double? Distance { get => fields.Distance[this]; set => fields.Distance[this] = value; }

    [DisplayName("Name Username"), Origin(jName, nameof(Administration.UserRow.Username))]
    public string NameUsername { get => fields.NameUsername[this]; set => fields.NameUsername[this] = value; }

    [DisplayName("Approved By Username"), Origin(jApprovedBy, nameof(Administration.UserRow.Username))]
    public string ApprovedByUsername { get => fields.ApprovedByUsername[this]; set => fields.ApprovedByUsername[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField UserId;
        public Int32Field Name;
        public DateTimeField DateNTime;
        public Int32Field Type;
        public StringField Coordinates;
        public StringField PunchOutCoordinates;
        public StringField Location;
        public Int32Field ApprovedBy;
        public DateTimeField PunchIn;
        public DateTimeField PunchOut;
        public DoubleField Distance;

        public StringField NameUsername;
        public StringField ApprovedByUsername;
    }
}

public enum AttendanceType
{
    [Description("Present")]
    Present = 1,
    [Description("Half Day")]
    HalfDay = 2,
    [Description("Absent")]
    Absent = 3,
    [Description("On Leave")]
    OnLeave = 4
}