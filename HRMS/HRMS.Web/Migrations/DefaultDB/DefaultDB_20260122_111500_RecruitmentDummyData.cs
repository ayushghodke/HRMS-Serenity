using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260122_111500)]
    public class DefaultDB_20260122_111500_RecruitmentDummyData : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                -- Clear existing Recruitment dummy data
                DELETE FROM Interviews;
                DELETE FROM Candidates;
                DELETE FROM JobOpenings;

                -- Job Openings
                SET IDENTITY_INSERT JobOpenings ON;
                INSERT INTO JobOpenings (JobId, Title, Description, DepartmentId, HiringManagerId, Status, CreatedDate)
                VALUES (1, 'Senior .NET Developer', 'We are looking for an experienced .NET Developer to join our team.', 1, 5, 1, DATEADD(day, -5, GETDATE()));
                
                INSERT INTO JobOpenings (JobId, Title, Description, DepartmentId, HiringManagerId, Status, CreatedDate)
                VALUES (2, 'HR Executive', 'Looking for an enthusiastic HR Executive for recruitment and payroll.', 2, 3, 1, DATEADD(day, -3, GETDATE()));
                
                INSERT INTO JobOpenings (JobId, Title, Description, DepartmentId, HiringManagerId, Status, CreatedDate)
                VALUES (3, 'Graphic Designer', 'Creative designer needed for social media campaigns.', 3, 4, 1, DATEADD(day, -10, GETDATE()));
                SET IDENTITY_INSERT JobOpenings OFF;

                -- Candidates
                SET IDENTITY_INSERT Candidates ON;
                INSERT INTO Candidates (CandidateId, JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 1, 'Alice', 'Williams', 'alice.w@example.com', '9876543210', 1, DATEADD(day, -4, GETDATE()));

                INSERT INTO Candidates (CandidateId, JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (2, 1, 'Bob', 'Johnson', 'bob.j@example.com', '9898989898', 2, DATEADD(day, -3, GETDATE()));

                INSERT INTO Candidates (CandidateId, JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (3, 2, 'Charlie', 'Brown', 'charlie.b@example.com', '9123456789', 1, DATEADD(day, -2, GETDATE()));
                SET IDENTITY_INSERT Candidates OFF;

                -- Interviews
                SET IDENTITY_INSERT Interviews ON;
                INSERT INTO Interviews (InterviewId, CandidateId, InterviewerId, InterviewDate, Round, Rating, Comments)
                VALUES (1, 2, 5, DATEADD(day, 1, GETDATE()), 1, NULL, 'Scheduled for technical round.');

                INSERT INTO Interviews (InterviewId, CandidateId, InterviewerId, InterviewDate, Round, Rating, Comments)
                VALUES (2, 1, 5, DATEADD(day, -1, GETDATE()), 1, 4, 'Good knowledge of C# and SQL. Recommended for next round.');
                SET IDENTITY_INSERT Interviews OFF;
            ");
        }

        public override void Down()
        {
        }
    }
}
