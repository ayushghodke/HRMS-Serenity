using Serenity.ComponentModel;
using HRMS.HR;

namespace HRMS.Recruitment.Forms;

[FormScript("Recruitment.JobOpenings")]
[BasedOnRow(typeof(JobOpeningsRow), CheckNames = true)]
public class JobOpeningsForm
{
    public string Title { get; set; }
    [TextAreaEditor(Rows = 5)]
    public string Description { get; set; }
    [LookupEditor(typeof(DepartmentRow))]
    public int DepartmentId { get; set; }
    [LookupEditor(typeof(EmployeeRow))]
    public int HiringManagerId { get; set; }
    public int Status { get; set; }
    [DefaultValue("now")]
    public DateTime CreatedDate { get; set; }
}
