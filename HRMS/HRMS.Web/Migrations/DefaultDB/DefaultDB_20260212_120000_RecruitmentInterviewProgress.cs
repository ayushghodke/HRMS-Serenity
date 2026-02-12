using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260212_120000)]
public class DefaultDB_20260212_120000_RecruitmentInterviewProgress : Migration
{
    public override void Up()
    {
        Alter.Table("Interviews")
            .AddColumn("IsCompleted").AsBoolean().NotNullable().WithDefaultValue(false)
            .AddColumn("CompletedOn").AsDateTime().Nullable();

        Execute.Sql(@"
            UPDATE Interviews
            SET IsCompleted = 1,
                CompletedOn = ISNULL(CompletedOn, InterviewDate)
            WHERE Rating IS NOT NULL OR InterviewDate < GETDATE();

            UPDATE c
            SET c.Status = 3
            FROM Candidates c
            WHERE EXISTS (
                SELECT 1
                FROM Interviews i
                WHERE i.CandidateId = c.CandidateId
                  AND i.IsCompleted = 1
            );
        ");
    }

    public override void Down()
    {
        Delete.Column("CompletedOn").FromTable("Interviews");
        Delete.Column("IsCompleted").FromTable("Interviews");
    }
}
