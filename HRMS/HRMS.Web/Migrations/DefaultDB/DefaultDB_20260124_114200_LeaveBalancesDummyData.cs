using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260124_114200)]
    public class DefaultDB_20260124_114200_LeaveBalancesDummyData : Migration
    {
        public override void Up()
        {
            // Insert default leave balances for existing employees (current year)
            Execute.Sql(@"
                INSERT INTO LeaveBalances (EmployeeId, LeaveType, Year, Allocated, Used)
                SELECT 
                    e.EmployeeId,
                    lt.LeaveType,
                    2026 AS Year,
                    CASE 
                        WHEN lt.LeaveType = 1 THEN 12.00  -- Casual
                        WHEN lt.LeaveType = 2 THEN 10.00  -- Sick
                        WHEN lt.LeaveType = 3 THEN 15.00  -- Earned
                        WHEN lt.LeaveType = 4 THEN 0.00   -- Unpaid (no allocation)
                    END AS Allocated,
                    0.00 AS Used
                FROM Employees e
                CROSS JOIN (VALUES (1), (2), (3), (4)) AS lt(LeaveType)
                WHERE e.Status = 1  -- Only active employees
            ");
        }

        public override void Down()
        {
            // Remove seeded data
            Execute.Sql("DELETE FROM LeaveBalances WHERE Year = 2026");
        }
    }
}
