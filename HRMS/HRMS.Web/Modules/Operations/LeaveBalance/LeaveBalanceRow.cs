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

    [DisplayName("Used"), Expression("(CASE WHEN T0.LeaveType = 1 THEN ISNULL((SELECT SUM(ISNULL(L.PaidDays, CASE WHEN L.LeaveType = 1 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) ELSE ISNULL((SELECT SUM(ISNULL(L.UnpaidDays, CASE WHEN L.LeaveType = 2 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) END)")]
    public decimal? Used { get => fields.Used[this]; set => fields.Used[this] = value; }

    [DisplayName("Balance"), Expression("(Allocated - (CASE WHEN T0.LeaveType = 1 THEN ISNULL((SELECT SUM(ISNULL(L.PaidDays, CASE WHEN L.LeaveType = 1 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) ELSE ISNULL((SELECT SUM(ISNULL(L.UnpaidDays, CASE WHEN L.LeaveType = 2 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) END))")]
    public decimal? Balance { get => fields.Balance[this]; set => fields.Balance[this] = value; }

    [DisplayName("Employee Name"), Origin(jEmployee, nameof(EmployeeRow.FullName))]
    public string EmployeeFullName { get => fields.EmployeeFullName[this]; set => fields.EmployeeFullName[this] = value; }

    [DisplayName("Join Date"), Origin(jEmployee, nameof(EmployeeRow.JoiningDate))]
    public DateTime? EmployeeJoinDate { get => fields.EmployeeJoinDate[this]; set => fields.EmployeeJoinDate[this] = value; }

    [DisplayName("Paid Leaves / Month"), Origin(jEmployee, nameof(EmployeeRow.PaidLeavesPerMonth))]
    public int? EmployeePaidLeavesPerMonth { get => fields.EmployeePaidLeavesPerMonth[this]; set => fields.EmployeePaidLeavesPerMonth[this] = value; }

    [DisplayName("Months Worked"), Expression("ISNULL(DATEDIFF(MONTH, jEmployee.JoiningDate, GETDATE()) + 1, 0)")]
    public int? MonthsWorked { get => fields.MonthsWorked[this]; set => fields.MonthsWorked[this] = value; }

    [DisplayName("Accrued Leaves"), Expression("ISNULL((DATEDIFF(MONTH, jEmployee.JoiningDate, GETDATE()) + 1) * ISNULL(jEmployee.PaidLeavesPerMonth, 2), 0)")]
    public int? AccruedLeaves { get => fields.AccruedLeaves[this]; set => fields.AccruedLeaves[this] = value; }

    [DisplayName("Remaining"), Expression("(ISNULL((DATEDIFF(MONTH, jEmployee.JoiningDate, GETDATE()) + 1) * ISNULL(jEmployee.PaidLeavesPerMonth, 2), 0) - (CASE WHEN T0.LeaveType = 1 THEN ISNULL((SELECT SUM(ISNULL(L.PaidDays, CASE WHEN L.LeaveType = 1 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) ELSE ISNULL((SELECT SUM(ISNULL(L.UnpaidDays, CASE WHEN L.LeaveType = 2 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) END))")]
    public decimal? RemainingLeaves { get => fields.RemainingLeaves[this]; set => fields.RemainingLeaves[this] = value; }

    [DisplayName("This Month"), Expression("(CASE WHEN T0.LeaveType = 1 THEN ISNULL((SELECT SUM(ISNULL(L.PaidDays, CASE WHEN L.LeaveType = 1 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1 AND MONTH(L.StartDate) = MONTH(GETDATE()) AND YEAR(L.StartDate) = YEAR(GETDATE())), 0) ELSE ISNULL((SELECT SUM(ISNULL(L.UnpaidDays, CASE WHEN L.LeaveType = 2 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1 AND MONTH(L.StartDate) = MONTH(GETDATE()) AND YEAR(L.StartDate) = YEAR(GETDATE())), 0) END)")]
    public decimal? LeavesThisMonth { get => fields.LeavesThisMonth[this]; set => fields.LeavesThisMonth[this] = value; }

    [DisplayName("Previous Months"), Expression("((CASE WHEN T0.LeaveType = 1 THEN ISNULL((SELECT SUM(ISNULL(L.PaidDays, CASE WHEN L.LeaveType = 1 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) ELSE ISNULL((SELECT SUM(ISNULL(L.UnpaidDays, CASE WHEN L.LeaveType = 2 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1), 0) END) - (CASE WHEN T0.LeaveType = 1 THEN ISNULL((SELECT SUM(ISNULL(L.PaidDays, CASE WHEN L.LeaveType = 1 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1 AND MONTH(L.StartDate) = MONTH(GETDATE()) AND YEAR(L.StartDate) = YEAR(GETDATE())), 0) ELSE ISNULL((SELECT SUM(ISNULL(L.UnpaidDays, CASE WHEN L.LeaveType = 2 THEN ISNULL(L.TotalDays, 0) ELSE 0 END)) FROM Leaves L WHERE L.EmployeeId = T0.EmployeeId AND L.Status = 1 AND MONTH(L.StartDate) = MONTH(GETDATE()) AND YEAR(L.StartDate) = YEAR(GETDATE())), 0) END))")]
    public decimal? LeavesPreviousMonths { get => fields.LeavesPreviousMonths[this]; set => fields.LeavesPreviousMonths[this] = value; }

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
        public DateTimeField EmployeeJoinDate;
        public Int32Field EmployeePaidLeavesPerMonth;
        public Int32Field MonthsWorked;
        public Int32Field AccruedLeaves;
        public DecimalField RemainingLeaves;
        public DecimalField LeavesThisMonth;
        public DecimalField LeavesPreviousMonths;
    }
}
