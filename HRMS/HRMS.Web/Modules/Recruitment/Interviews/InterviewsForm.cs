using Serenity.ComponentModel;
using HRMS.HR;

namespace HRMS.Recruitment.Forms;

[FormScript("Recruitment.Interviews")]
[BasedOnRow(typeof(InterviewsRow), CheckNames = true)]
public class InterviewsForm
{
    [LookupEditor(typeof(CandidatesRow))]
    public int CandidateId { get; set; }
    [LookupEditor(typeof(EmployeeRow))]
    public int InterviewerId { get; set; }
    [DefaultValue("now")]
    public DateTime InterviewDate { get; set; }
    public int Round { get; set; }
    public int Rating { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Comments { get; set; }
    [DisplayName("Interview Done")]
    public bool IsCompleted { get; set; }
}
