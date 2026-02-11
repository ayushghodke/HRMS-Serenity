using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using System.Collections.Generic;

namespace HRMS.HR;

[ConnectionKey("Default"), Module("HR"), TableName("EmployeeSalary")]
[DisplayName("Employee Salary"), InstanceName("Salary Assignment")]
[ReadPermission("HR:Employee:View")]
[ModifyPermission("HR:Employee:Modify")]
public sealed class EmployeeSalaryRow : Row<EmployeeSalaryRow.RowFields>, IIdRow
{
    [DisplayName("Employee Salary Id"), Identity, IdProperty]
    public int? EmployeeSalaryId { get => fields.EmployeeSalaryId[this]; set => fields.EmployeeSalaryId[this] = value; }

    [DisplayName("Employee"), NotNull, ForeignKey("Employees", "EmployeeId"), LeftJoin("jEmployee")]
    [LookupEditor(typeof(EmployeeRow))]
    [TextualField(nameof(EmployeeName))]
    public int? EmployeeId { get => fields.EmployeeId[this]; set => fields.EmployeeId[this] = value; }

    [DisplayName("Salary Grade"), ForeignKey("SalaryGrades", "GradeId"), LeftJoin("jGrade")]
    [LookupEditor(typeof(Operations.SalaryGradeRow))]
    [TextualField(nameof(GradeName))]
    public int? GradeId { get => fields.GradeId[this]; set => fields.GradeId[this] = value; }

    [DisplayName("Effective Date"), NotNull]
    public DateTime? EffectiveDate { get => fields.EffectiveDate[this]; set => fields.EffectiveDate[this] = value; }

    [DisplayName("Basic Salary"), Size(19), Scale(2), NotNull]
    public decimal? BasicSalary { get => fields.BasicSalary[this]; set => fields.BasicSalary[this] = value; }

    [DisplayName("Gross Salary"), Size(19), Scale(2), NotNull]
    public decimal? GrossSalary { get => fields.GrossSalary[this]; set => fields.GrossSalary[this] = value; }

    [DisplayName("Is Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

    [DisplayName("Employee Name"), Expression("jEmployee.[FirstName] + ' ' + jEmployee.[LastName]"), QuickSearch]
    public string EmployeeName { get => fields.EmployeeName[this]; set => fields.EmployeeName[this] = value; }

    [DisplayName("Grade Name"), Expression("jGrade.[GradeName]")]
    public string GradeName { get => fields.GradeName[this]; set => fields.GradeName[this] = value; }

    [DisplayName("Salary Details"), MasterDetailRelation(foreignKey: "EmployeeSalaryId"), NotMapped]
    public List<EmployeeSalaryDetailsRow> DetailList { get => fields.DetailList[this]; set => fields.DetailList[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field EmployeeSalaryId;
        public Int32Field EmployeeId;
        public Int32Field GradeId;
        public DateTimeField EffectiveDate;
        public DecimalField BasicSalary;
        public DecimalField GrossSalary;
        public BooleanField IsActive;

        public StringField EmployeeName;
        public StringField GradeName;

        public RowListField<EmployeeSalaryDetailsRow> DetailList;
    }
}
