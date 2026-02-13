using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace HRMS.Recruitment;

[ConnectionKey("Default"), Module("Recruitment"), TableName("Candidates")]
[DisplayName("Candidates"), InstanceName("Candidates")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
[LookupScript]
public sealed class CandidatesRow : Row<CandidatesRow.RowFields>, IIdRow, INameRow
{
    const string jJob = nameof(jJob);

    [DisplayName("Candidate Id"), Identity, IdProperty]
    public int? CandidateId { get => fields.CandidateId[this]; set => fields.CandidateId[this] = value; }

    [DisplayName("Job"), NotNull, ForeignKey("JobOpenings", "JobId"), LeftJoin(jJob), TextualField(nameof(JobTitle))]
    [LookupEditor(typeof(JobOpeningsRow))]
    public int? JobId { get => fields.JobId[this]; set => fields.JobId[this] = value; }

    [DisplayName("First Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string FirstName { get => fields.FirstName[this]; set => fields.FirstName[this] = value; }

    [DisplayName("Last Name"), Size(100), NotNull]
    public string LastName { get => fields.LastName[this]; set => fields.LastName[this] = value; }

    [DisplayName("Email"), Size(100), NotNull]
    public string Email { get => fields.Email[this]; set => fields.Email[this] = value; }

    [DisplayName("Mobile"), Size(20)]
    public string Mobile { get => fields.Mobile[this]; set => fields.Mobile[this] = value; }

    [DisplayName("Resume"), Size(1000), FileUploadEditor(FilenameFormat = "CandidateResumes/~", CopyToHistory = true)]
    public string Resume { get => fields.Resume[this]; set => fields.Resume[this] = value; }

    [DisplayName("Progress Status"), NotNull, DefaultValue(CandidateStatus.Applied)]
    public CandidateStatus? Status { get => (CandidateStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Applied Date"), NotNull]
    public DateTime? AppliedDate { get => fields.AppliedDate[this]; set => fields.AppliedDate[this] = value; }

    [DisplayName("Job Title"), Expression($"{jJob}.[Title]")]
    public string JobTitle { get => fields.JobTitle[this]; set => fields.JobTitle[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field CandidateId;
        public Int32Field JobId;
        public StringField FirstName;
        public StringField LastName;
        public StringField Email;
        public StringField Mobile;
        public StringField Resume;
        public Int32Field Status;
        public DateTimeField AppliedDate;

        public StringField JobTitle;
    }
}

public enum CandidateStatus
{
    [Description("Applied")]
    Applied = 1,
    [Description("Shortlisted")]
    Shortlisted = 2,
    [Description("Interview Completed")]
    Interviewed = 3,
    [Description("Offered")]
    Offered = 4,
    [Description("Hired")]
    Hired = 5,
    [Description("Rejected")]
    Rejected = 0
}
