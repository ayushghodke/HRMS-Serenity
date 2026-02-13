using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260213_110000)]
public class DefaultDB_20260213_110000_RenameCandidateResumeColumn : Migration
{
    public override void Up()
    {
        Rename.Column("ResumePath").OnTable("Candidates").To("Resume");
    }

    public override void Down()
    {
        Rename.Column("Resume").OnTable("Candidates").To("ResumePath");
    }
}
