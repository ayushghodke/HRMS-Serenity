using Serenity.ComponentModel;

namespace HRMS.HR.Forms;

[FormScript("HR.Employee")]
[BasedOnRow(typeof(EmployeeRow), CheckNames = true)]
public class EmployeeForm
{
    [Tab("General")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }

    [Tab("Employment")]
    public DateTime JoiningDate { get; set; }
    public int DepartmentId { get; set; }
    public int DesignationId { get; set; }
    public int ManagerId { get; set; }
    public EmploymentType EmploymentType { get; set; }
    public EmployeeStatus Status { get; set; }

    [Tab("User")]
    public int UserId { get; set; }
}
