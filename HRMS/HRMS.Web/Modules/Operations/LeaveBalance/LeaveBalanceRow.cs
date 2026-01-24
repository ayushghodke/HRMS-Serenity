using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using HRMS.HR;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("LeaveBalances")]
[DisplayName("Leave Balances"), InstanceName("Leave Balance")]
[ReadPermission("Operations:Leave")]
[ModifyPermission("Operations:Leave")]
[LookupScript]
public sealed class LeaveBalanceRow : Row<LeaveBalanceRow.RowFields>, IIdRow
{
    const string jEmployee = nameof(jEmployee);

    [DisplayName("Leave Balance Id"), Identity, IdProperty]
    public int? LeaveBalanceId { get => fields.LeaveBalanceId[this]; set => fields.LeaveBalanceId[this] = value; }

    [DisplayName("Employee"), NotNull, ForeignKey(typeof(EmployeeRow)), LeftJoin(jEmployee), TextualField(nameof(EmployeeFullName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? EmployeeId { get => fields.EmployeeId[this]; set => fields.EmployeeId[this] = value; }

    [DisplayName("Leave Type"), NotNull]
    public LeaveType? LeaveType { get => (LeaveType?)fields.LeaveType[this]; set => fields.LeaveType[this] = (int?)value; }

    [DisplayName("Year"), NotNull]
    public int? Year { get => fields.Year[this]; set => fields.Year[this] = value; }

    [DisplayName("Allocated"), NotNull, DefaultValue(0)]
    public decimal? Allocated { get => fields.Allocated[this]; set => fields.Allocated[this] = value; }

    [DisplayName("Used"), NotNull, DefaultValue(0)]
    public decimal? Used { get => fields.Used[this]; set => fields.Used[this] = value; }

    [DisplayName("Balance"), Expression("(Allocated - Used)")]
    public decimal? Balance { get => fields.Balance[this]; set => fields.Balance[this] = value; }

    [DisplayName("Employee Name"), Origin(jEmployee, nameof(EmployeeRow.FullName))]
    public string EmployeeFullName { get => fields.EmployeeFullName[this]; set => fields.EmployeeFullName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field LeaveBalanceId;
        public Int32Field EmployeeId;
        public Int32Field LeaveType;
        public Int32Field Year;
        public DecimalField Allocated;
        public DecimalField Used;
        public DecimalField Balance;

        public StringField EmployeeFullName;
    }
}
