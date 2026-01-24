using Serenity.ComponentModel;

namespace HRMS.Recruitment.Columns;

[ColumnsScript("Recruitment.JobOpenings")]
[BasedOnRow(typeof(JobOpeningsRow), CheckNames = true)]
public class JobOpeningsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int JobId { get; set; }
    [EditLink]
    public string Title { get; set; }
    public string Description { get; set; }
    public string DepartmentName { get; set; }
    public string HiringManagerName { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
