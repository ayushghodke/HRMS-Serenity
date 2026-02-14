using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260214_150000)]
public class DefaultDB_20260214_150000_EmployeeMonthlyPaidLeaves : Migration
{
    public override void Up()
    {
        Alter.Table("Employees")
            .AddColumn("PaidLeavesPerMonth").AsInt32().NotNullable().WithDefaultValue(2);

        Alter.Table("Leaves")
            .AddColumn("PaidDays").AsDecimal(5, 2).NotNullable().WithDefaultValue(0)
            .AddColumn("UnpaidDays").AsDecimal(5, 2).NotNullable().WithDefaultValue(0);

        Execute.Sql(@"
            UPDATE Leaves
            SET
                PaidDays = CASE WHEN LeaveType = 1 THEN ISNULL(TotalDays, 0) ELSE 0 END,
                UnpaidDays = CASE WHEN LeaveType = 2 THEN ISNULL(TotalDays, 0) ELSE 0 END
        ");

        Execute.Sql("DELETE FROM LeaveBalances WHERE LeaveType NOT IN (1, 2)");
    }

    public override void Down()
    {
        Delete.Column("PaidDays").FromTable("Leaves");
        Delete.Column("UnpaidDays").FromTable("Leaves");
        Delete.Column("PaidLeavesPerMonth").FromTable("Employees");
    }
}
