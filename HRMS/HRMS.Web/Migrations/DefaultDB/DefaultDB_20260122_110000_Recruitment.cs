using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260122_110000)]
    public class DefaultDB_20260122_110000_Recruitment : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("JobOpenings")
                .WithColumn("JobId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString(200).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("DepartmentId").AsInt32().Nullable()
                    .ForeignKey("FK_JobOpenings_DepartmentId", "Departments", "DepartmentId")
                .WithColumn("HiringManagerId").AsInt32().Nullable()
                    .ForeignKey("FK_JobOpenings_HiringManagerId", "Employees", "EmployeeId")
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1) // 1=Open
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime);

            Create.Table("Candidates")
                .WithColumn("CandidateId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("JobId").AsInt32().NotNullable()
                    .ForeignKey("FK_Candidates_JobId", "JobOpenings", "JobId")
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("LastName").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("Mobile").AsString(20).Nullable()
                .WithColumn("ResumePath").AsString(500).Nullable()
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1) // 1=Applied
                .WithColumn("AppliedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime);

            Create.Table("Interviews")
                .WithColumn("InterviewId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("CandidateId").AsInt32().NotNullable()
                    .ForeignKey("FK_Interviews_CandidateId", "Candidates", "CandidateId")
                .WithColumn("InterviewerId").AsInt32().Nullable()
                    .ForeignKey("FK_Interviews_InterviewerId", "Employees", "EmployeeId")
                .WithColumn("InterviewDate").AsDateTime().NotNullable()
                .WithColumn("Round").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Rating").AsInt32().Nullable()
                .WithColumn("Comments").AsString(int.MaxValue).Nullable();
        }
    }
}
