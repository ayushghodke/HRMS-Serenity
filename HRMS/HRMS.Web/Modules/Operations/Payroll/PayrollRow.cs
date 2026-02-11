using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using HRMS.HR;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("Payroll")]
[DisplayName("Payroll"), InstanceName("Payroll")]
[ReadPermission("Operations:Payroll")]
[ModifyPermission("Operations:Payroll")]
[LookupScript]
public sealed class PayrollRow : Row<PayrollRow.RowFields>, IIdRow, INameRow
{
    const string jEmployee = nameof(jEmployee);

    [DisplayName("Payroll Id"), Identity, IdProperty]
    public int? PayrollId { get => fields.PayrollId[this]; set => fields.PayrollId[this] = value; }

    [DisplayName("Employee"), NotNull, ForeignKey(typeof(EmployeeRow)), LeftJoin(jEmployee), TextualField(nameof(EmployeeFullName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? EmployeeId { get => fields.EmployeeId[this]; set => fields.EmployeeId[this] = value; }

    [DisplayName("Month"), NotNull]
    public Month? Month { get => (Month?)fields.Month[this]; set => fields.Month[this] = (int?)value; }

    [DisplayName("Year"), NotNull]
    public int? Year { get => fields.Year[this]; set => fields.Year[this] = value; }

    [DisplayName("Basic Salary"), NotNull, DisplayFormat("#,##0.00")]
    public decimal? BasicSalary { get => fields.BasicSalary[this]; set => fields.BasicSalary[this] = value; }

    [DisplayName("Allowances"), NotNull, DisplayFormat("#,##0.00"), DefaultValue(0)]
    public decimal? Allowances { get => fields.Allowances[this]; set => fields.Allowances[this] = value; }

    [DisplayName("Deductions"), NotNull, DisplayFormat("#,##0.00"), DefaultValue(0)]
    public decimal? Deductions { get => fields.Deductions[this]; set => fields.Deductions[this] = value; }

    [DisplayName("Net Salary"), NotNull, DisplayFormat("#,##0.00")] // Should probably be calculated
    public decimal? NetSalary { get => fields.NetSalary[this]; set => fields.NetSalary[this] = value; }

    [DisplayName("Generated Date")]
    public DateTime? GeneratedDate { get => fields.GeneratedDate[this]; set => fields.GeneratedDate[this] = value; }

    [DisplayName("Employee Name"), Origin(jEmployee, nameof(EmployeeRow.FullName)), QuickSearch, NameProperty]
    public string EmployeeFullName { get => fields.EmployeeFullName[this]; set => fields.EmployeeFullName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field PayrollId;
        public Int32Field EmployeeId;
        public Int32Field Month;
        public Int32Field Year;
        public DecimalField BasicSalary;
        public DecimalField Allowances;
        public DecimalField Deductions;
        public DecimalField NetSalary;
        public DateTimeField GeneratedDate;

        public StringField EmployeeFullName;
    }
}

public enum Month
{
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    September = 9,
    October = 10,
    November = 11,
    December = 12
}
