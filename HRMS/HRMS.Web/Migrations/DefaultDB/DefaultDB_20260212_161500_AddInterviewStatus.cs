using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260212_161500)]
public class DefaultDB_20260212_161500_AddInterviewStatus : Migration
{
    public override void Up()
    {
        Alter.Table("Interviews")
            .AddColumn("Status").AsInt32().NotNullable().WithDefaultValue(1); // 1 = Scheduled

        // Migrate existing data:
        // If IsCompleted is true, set Status to Interviewed (2)
        Execute.Sql(@"
            UPDATE Interviews
            SET Status = 2
            WHERE IsCompleted = 1;
        ");
    }

    public override void Down()
    {
        Delete.Column("Status").FromTable("Interviews");
    }
}
