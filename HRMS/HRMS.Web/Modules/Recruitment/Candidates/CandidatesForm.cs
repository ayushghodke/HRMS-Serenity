namespace HRMS.Recruitment.Forms;

[FormScript("Recruitment.Candidates")]
[BasedOnRow(typeof(CandidatesRow), CheckNames = true)]
public class CandidatesForm
{
    [LookupEditor(typeof(JobOpeningsRow))]
    public int JobId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Resume { get; set; }
    public CandidateStatus Status { get; set; }
    public DateTime AppliedDate { get; set; }
}
