using Serenity.ComponentModel;
using System.ComponentModel;
using HRMS.Administration;

namespace HRMS.HR.Columns;

[ColumnsScript("HR.Employee")]
[BasedOnRow(typeof(EmployeeRow), CheckNames = true)]
public class EmployeeColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int EmployeeId { get; set; }
    [EditLink]
    public string EmployeeCode { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int PaidLeavesPerMonth { get; set; }
    public string DepartmentName { get; set; }
    public string DesignationName { get; set; }
    [Width(100), AlignCenter]
    public EmployeeStatus Status { get; set; }
}
