using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using HRMS.HR;
using HRMS.Administration;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("Tasks")]
[DisplayName("Tasks"), InstanceName("Task")]
[ReadPermission("Operations:Task")]
[ModifyPermission("Operations:Task")]
[LookupScript]
public sealed class TaskRow : Row<TaskRow.RowFields>, IIdRow, INameRow
{
    const string jAssignedTo = nameof(jAssignedTo);
    const string jAssignedBy = nameof(jAssignedBy);

    [DisplayName("Task Id"), Identity, IdProperty]
    public int? TaskId { get => fields.TaskId[this]; set => fields.TaskId[this] = value; }

    [DisplayName("Title"), Size(200), NotNull, QuickSearch, NameProperty]
    public string Title { get => fields.Title[this]; set => fields.Title[this] = value; }

    [DisplayName("Description"), Size(1000)]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Assigned To"), NotNull, ForeignKey(typeof(EmployeeRow)), LeftJoin(jAssignedTo), TextualField(nameof(AssignedToFullName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? AssignedTo { get => fields.AssignedTo[this]; set => fields.AssignedTo[this] = value; }

    [DisplayName("Assigned By"), ForeignKey(typeof(UserRow)), LeftJoin(jAssignedBy), TextualField(nameof(AssignedByUsername))]
    [LookupEditor(typeof(UserRow), Async = true)]
    public int? AssignedBy { get => fields.AssignedBy[this]; set => fields.AssignedBy[this] = value; }

    [DisplayName("Due Date"), NotNull]
    public DateTime? DueDate { get => fields.DueDate[this]; set => fields.DueDate[this] = value; }

    [DisplayName("Status"), NotNull, DefaultValue(TaskStatus.Open)]
    public TaskStatus? Status { get => (TaskStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Assigned To Name"), Origin(jAssignedTo, nameof(EmployeeRow.FullName))]
    public string AssignedToFullName { get => fields.AssignedToFullName[this]; set => fields.AssignedToFullName[this] = value; }

    [DisplayName("Assigned By Username"), Origin(jAssignedBy, nameof(UserRow.Username))]
    public string AssignedByUsername { get => fields.AssignedByUsername[this]; set => fields.AssignedByUsername[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field TaskId;
        public StringField Title;
        public StringField Description;
        public Int32Field AssignedTo;
        public Int32Field AssignedBy;
        public DateTimeField DueDate;
        public Int32Field Status;

        public StringField AssignedToFullName;
        public StringField AssignedByUsername;
    }
}

public enum TaskStatus
{
    [Description("Open")]
    Open = 0,
    [Description("In Progress")]
    In_Progress = 1,
    [Description("Completed")]
    Completed = 2,
    [Description("On Hold")]
    On_Hold = 3,
    [Description("Cancelled")]
    Cancelled = -1
}
