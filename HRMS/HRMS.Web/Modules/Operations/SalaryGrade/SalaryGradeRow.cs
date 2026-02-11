using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("SalaryGrades")]
[DisplayName("Salary Grades"), InstanceName("Salary Grade")]
[ReadPermission("Operations:Payroll")]
[ModifyPermission("Operations:Payroll")]
[LookupScript]
public sealed class SalaryGradeRow : Row<SalaryGradeRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Grade Id"), Identity, IdProperty]
    public int? GradeId { get => fields.GradeId[this]; set => fields.GradeId[this] = value; }

    [DisplayName("Grade Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string GradeName { get => fields.GradeName[this]; set => fields.GradeName[this] = value; }

    [DisplayName("Grade Code"), Size(50)]
    public string GradeCode { get => fields.GradeCode[this]; set => fields.GradeCode[this] = value; }

    [DisplayName("Min Salary"), Size(19), Scale(2)]
    public decimal? MinSalary { get => fields.MinSalary[this]; set => fields.MinSalary[this] = value; }

    [DisplayName("Max Salary"), Size(19), Scale(2)]
    public decimal? MaxSalary { get => fields.MaxSalary[this]; set => fields.MaxSalary[this] = value; }

    [DisplayName("Description"), Size(500)]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Is Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field GradeId;
        public StringField GradeName;
        public StringField GradeCode;
        public DecimalField MinSalary;
        public DecimalField MaxSalary;
        public StringField Description;
        public BooleanField IsActive;
    }
}
