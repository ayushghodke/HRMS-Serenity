using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using HRMS.HR;

namespace HRMS.Recruitment;

[ConnectionKey("Default"), Module("Recruitment"), TableName("Interviews")]
[DisplayName("Interviews"), InstanceName("Interview")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[LookupScript]
public sealed class InterviewsRow : Row<InterviewsRow.RowFields>, IIdRow
{
    const string jCandidate = nameof(jCandidate);
    const string jInterviewer = nameof(jInterviewer);

    [DisplayName("Interview Id"), Identity, IdProperty]
    public int? InterviewId { get => fields.InterviewId[this]; set => fields.InterviewId[this] = value; }

    [DisplayName("Candidate"), NotNull, ForeignKey("Candidates", "CandidateId"), LeftJoin(jCandidate), TextualField(nameof(CandidateName))]
    [LookupEditor(typeof(CandidatesRow))]
    public int? CandidateId { get => fields.CandidateId[this]; set => fields.CandidateId[this] = value; }

    [DisplayName("Interviewer"), ForeignKey(typeof(EmployeeRow)), LeftJoin(jInterviewer), TextualField(nameof(InterviewerName))]
    [LookupEditor(typeof(EmployeeRow))]
    public int? InterviewerId { get => fields.InterviewerId[this]; set => fields.InterviewerId[this] = value; }

    [DisplayName("Interview Date"), NotNull]
    public DateTime? InterviewDate { get => fields.InterviewDate[this]; set => fields.InterviewDate[this] = value; }

    [DisplayName("Round"), NotNull, DefaultValue(InterviewRound.Technical)]
    public InterviewRound? Round { get => (InterviewRound?)fields.Round[this]; set => fields.Round[this] = (int?)value; }

    [DisplayName("Rating")]
    public int? Rating { get => fields.Rating[this]; set => fields.Rating[this] = value; }

    [DisplayName("Comments"), Size(int.MaxValue)]
    public string Comments { get => fields.Comments[this]; set => fields.Comments[this] = value; }

    [DisplayName("Candidate"), Expression($"{jCandidate}.[FirstName] + ' ' + {jCandidate}.[LastName]"), MinSelectLevel(SelectLevel.List)]
    public string CandidateName { get => fields.CandidateName[this]; set => fields.CandidateName[this] = value; }

    [DisplayName("Interviewer"), Expression($"{jInterviewer}.[FirstName] + ' ' + {jInterviewer}.[LastName]"), MinSelectLevel(SelectLevel.List)]
    public string InterviewerName { get => fields.InterviewerName[this]; set => fields.InterviewerName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field InterviewId;
        public Int32Field CandidateId;
        public Int32Field InterviewerId;
        public DateTimeField InterviewDate;
        public Int32Field Round;
        public Int32Field Rating;
        public StringField Comments;

        public StringField CandidateName;
        public StringField InterviewerName;
    }
}

public enum InterviewRound
{
    [Description("Technical Round")]
    Technical = 1,
    [Description("HR Round")]
    HR = 2,
    [Description("Management Round")]
    Management = 3,
    [Description("Final Round")]
    Final = 4
}
