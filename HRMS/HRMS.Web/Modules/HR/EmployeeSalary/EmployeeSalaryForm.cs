using Serenity.ComponentModel;
using System;
using System.Collections.Generic;

namespace HRMS.HR.Forms;

[FormScript("HR.EmployeeSalary")]
[BasedOnRow(typeof(EmployeeSalaryRow), CheckNames = true)]
public class EmployeeSalaryForm
{
    public int EmployeeId { get; set; }
    public int GradeId { get; set; }
    public DateTime EffectiveDate { get; set; }
    public decimal BasicSalary { get; set; }
    [ReadOnly(true)]
    public decimal GrossSalary { get; set; }
    
    [Category("Salary Components")]
    [EditorType("HRMS.HR.EmployeeSalaryDetailsEditor")]
    public List<EmployeeSalaryDetailsRow> DetailList { get; set; }
    
    public bool IsActive { get; set; }
}
