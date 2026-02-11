using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.HR;

[ConnectionKey("Default"), Module("HR"), TableName("EmployeeSalaryDetails")]
[DisplayName("Employee Salary Details"), InstanceName("Salary Detail")]
[ReadPermission("HR:Employee:View")]
[ModifyPermission("HR:Employee:Modify")]
public sealed class EmployeeSalaryDetailsRow : Row<EmployeeSalaryDetailsRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Detail Id"), Identity, IdProperty]
    public int? DetailId { get => fields.DetailId[this]; set => fields.DetailId[this] = value; }

    [DisplayName("Employee Salary"), NotNull, ForeignKey("EmployeeSalary", "EmployeeSalaryId"), LeftJoin("jEmployeeSalary")]
    public int? EmployeeSalaryId { get => fields.EmployeeSalaryId[this]; set => fields.EmployeeSalaryId[this] = value; }

    [DisplayName("Component"), NotNull, ForeignKey("SalaryComponents", "ComponentId"), LeftJoin("jComponent")]
    [LookupEditor(typeof(Operations.SalaryComponentsRow))]
    [TextualField(nameof(ComponentName))]
    public int? ComponentId { get => fields.ComponentId[this]; set => fields.ComponentId[this] = value; }

    [DisplayName("Amount"), Size(19), Scale(2), NotNull]
    public decimal? Amount { get => fields.Amount[this]; set => fields.Amount[this] = value; }

    [DisplayName("Is Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

    [DisplayName("Component Name"), Expression("jComponent.[ComponentName]"), QuickSearch, NameProperty]
    public string ComponentName { get => fields.ComponentName[this]; set => fields.ComponentName[this] = value; }

    [DisplayName("Component Type"), Expression("jComponent.[ComponentType]")]
    public int? ComponentType { get => fields.ComponentType[this]; set => fields.ComponentType[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field DetailId;
        public Int32Field EmployeeSalaryId;
        public Int32Field ComponentId;
        public DecimalField Amount;
        public BooleanField IsActive;

        public StringField ComponentName;
        public Int32Field ComponentType;
    }
}
