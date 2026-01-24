using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260124_114100)]
    public class DefaultDB_20260124_114100_LeaveBalances : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("LeaveBalances")
                .WithColumn("LeaveBalanceId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("EmployeeId").AsInt32().NotNullable()
                    .ForeignKey("FK_LeaveBalances_EmployeeId", "Employees", "EmployeeId")
                .WithColumn("LeaveType").AsInt32().NotNullable() // Maps to LeaveType enum
                .WithColumn("Year").AsInt32().NotNullable()
                .WithColumn("Allocated").AsDecimal(5, 2).NotNullable().WithDefaultValue(0)
                .WithColumn("Used").AsDecimal(5, 2).NotNullable().WithDefaultValue(0);

            // Create unique index to prevent duplicate entries for same employee/type/year
            Create.Index("IX_LeaveBalances_Employee_Type_Year")
                .OnTable("LeaveBalances")
                .OnColumn("EmployeeId").Ascending()
                .OnColumn("LeaveType").Ascending()
                .OnColumn("Year").Ascending()
                .WithOptions().Unique();
        }
    }
}
