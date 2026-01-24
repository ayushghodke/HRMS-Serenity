using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Recruitment;

[ConnectionKey("Default"), Module("Recruitment"), TableName("JobOpenings")]
[DisplayName("Job Openings"), InstanceName("Job Opening")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[LookupScript]
public sealed class JobOpeningsRow : Row<JobOpeningsRow.RowFields>, IIdRow, INameRow
{
    const string jDepartment = nameof(jDepartment);
    const string jHiringManager = nameof(jHiringManager);

    [DisplayName("Job Id"), Identity, IdProperty]
    public int? JobId { get => fields.JobId[this]; set => fields.JobId[this] = value; }

    [DisplayName("Title"), Size(200), NotNull, QuickSearch, NameProperty]
    public string Title { get => fields.Title[this]; set => fields.Title[this] = value; }

    [DisplayName("Description"), Size(int.MaxValue)]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Department"), ForeignKey("Departments", "DepartmentId"), LeftJoin(jDepartment), TextualField(nameof(DepartmentName))]
    public int? DepartmentId { get => fields.DepartmentId[this]; set => fields.DepartmentId[this] = value; }

    [DisplayName("Hiring Manager"), ForeignKey("Employees", "EmployeeId"), LeftJoin(jHiringManager), TextualField(nameof(HiringManagerName))]
    public int? HiringManagerId { get => fields.HiringManagerId[this]; set => fields.HiringManagerId[this] = value; }

    [DisplayName("Status"), NotNull, DefaultValue(JobOpeningStatus.Open)]
    public JobOpeningStatus? Status { get => (JobOpeningStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Created Date"), NotNull]
    public DateTime? CreatedDate { get => fields.CreatedDate[this]; set => fields.CreatedDate[this] = value; }

    [DisplayName("Department"), Expression($"{jDepartment}.[DepartmentName]")]
    public string DepartmentName { get => fields.DepartmentName[this]; set => fields.DepartmentName[this] = value; }

    [DisplayName("Hiring Manager"), Expression($"{jHiringManager}.[FirstName] + ' ' + {jHiringManager}.[LastName]")]
    public string HiringManagerName { get => fields.HiringManagerName[this]; set => fields.HiringManagerName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field JobId;
        public StringField Title;
        public StringField Description;
        public Int32Field DepartmentId;
        public Int32Field HiringManagerId;
        public Int32Field Status;
        public DateTimeField CreatedDate;

        public StringField DepartmentName;
        public StringField HiringManagerName;
    }
}

public enum JobOpeningStatus
{
    [Description("Draft")]
    Draft = 0,
    [Description("Open")]
    Open = 1,
    [Description("Closed")]
    Closed = 2,
    [Description("On Hold")]
    OnHold = 3
}
