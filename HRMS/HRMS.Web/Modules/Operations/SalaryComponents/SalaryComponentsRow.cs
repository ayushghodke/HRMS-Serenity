using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("SalaryComponents")]
[DisplayName("Salary Components"), InstanceName("Salary Component")]
[ReadPermission("Operations:Payroll")]
[ModifyPermission("Operations:Payroll")]
[LookupScript]
public sealed class SalaryComponentsRow : Row<SalaryComponentsRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Component Id"), Identity, IdProperty]
    public int? ComponentId { get => fields.ComponentId[this]; set => fields.ComponentId[this] = value; }

    [DisplayName("Component Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string ComponentName { get => fields.ComponentName[this]; set => fields.ComponentName[this] = value; }

    [DisplayName("Component Type"), NotNull, DefaultValue(SalaryComponentType.Earning)]
    public SalaryComponentType? ComponentType { get => (SalaryComponentType?)fields.ComponentType[this]; set => fields.ComponentType[this] = (int?)value; }

    [DisplayName("Calculation Type"), NotNull, DefaultValue(SalaryCalculationType.Fixed)]
    public SalaryCalculationType? CalculationType { get => (SalaryCalculationType?)fields.CalculationType[this]; set => fields.CalculationType[this] = (int?)value; }

    [DisplayName("Percentage Of"), ForeignKey(typeof(SalaryComponentsRow)), LeftJoin("jPercentageOf")]
    [LookupEditor(typeof(SalaryComponentsRow), Async = true)]
    [TextualField(nameof(PercentageOfComponentName))]
    public int? PercentageOf { get => fields.PercentageOf[this]; set => fields.PercentageOf[this] = value; }

    [DisplayName("Is Statutory"), NotNull, DefaultValue(false)]
    public bool? IsStatutory { get => fields.IsStatutory[this]; set => fields.IsStatutory[this] = value; }

    [DisplayName("Is Taxable"), NotNull, DefaultValue(true)]
    public bool? IsTaxable { get => fields.IsTaxable[this]; set => fields.IsTaxable[this] = value; }

    [DisplayName("Is Active"), NotNull, DefaultValue(true)]
    public bool? IsActive { get => fields.IsActive[this]; set => fields.IsActive[this] = value; }

    [DisplayName("Display Order")]
    public int? DisplayOrder { get => fields.DisplayOrder[this]; set => fields.DisplayOrder[this] = value; }

    [DisplayName("Description"), Size(500), QuickSearch]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Percentage Of"), Origin("jPercentageOf", nameof(ComponentName))]
    public string PercentageOfComponentName { get => fields.PercentageOfComponentName[this]; set => fields.PercentageOfComponentName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field ComponentId;
        public StringField ComponentName;
        public Int32Field ComponentType;
        public Int32Field CalculationType;
        public Int32Field PercentageOf;
        public BooleanField IsStatutory;
        public BooleanField IsTaxable;
        public BooleanField IsActive;
        public Int32Field DisplayOrder;
        public StringField Description;

        public StringField PercentageOfComponentName;
    }
}

public enum SalaryComponentType
{
    [Description("Earning")]
    Earning = 1,
    
    [Description("Deduction")]
    Deduction = 2
}

public enum SalaryCalculationType
{
    [Description("Fixed Amount")]
    Fixed = 1,
    
    [Description("Percentage")]
    Percentage = 2,
    
    [Description("Formula")]
    Formula = 3
}
