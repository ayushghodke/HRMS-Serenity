using Serenity.ComponentModel;

namespace HRMS.Recruitment.Columns;

[ColumnsScript("Recruitment.Interviews")]
[BasedOnRow(typeof(InterviewsRow), CheckNames = true)]
public class InterviewsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int InterviewId { get; set; }
    [EditLink]
    public string CandidateName { get; set; }
    public string InterviewerName { get; set; }
    public DateTime InterviewDate { get; set; }
    public int Round { get; set; }
    public int Rating { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedOn { get; set; }
    public string Comments { get; set; }
}
