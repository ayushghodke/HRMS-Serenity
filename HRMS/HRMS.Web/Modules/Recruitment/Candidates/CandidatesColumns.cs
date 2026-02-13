namespace HRMS.Recruitment.Columns;

[ColumnsScript("Recruitment.Candidates")]
[BasedOnRow(typeof(CandidatesRow), CheckNames = true)]
public class CandidatesColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int CandidateId { get; set; }
    public string JobTitle { get; set; }
    [EditLink]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Resume { get; set; }
    [DisplayName("Progress Status")]
    public CandidateStatus Status { get; set; }
    public DateTime AppliedDate { get; set; }
}
