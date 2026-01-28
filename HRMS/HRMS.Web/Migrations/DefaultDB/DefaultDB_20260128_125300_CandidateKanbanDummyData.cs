using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260128_125300)]
    public class DefaultDB_20260128_125300_CandidateKanbanDummyData : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                -- Add more diverse candidates across all statuses for Kanban board demonstration
                
                -- Applied (Status = 1) - Fresh applications
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 'Priya', 'Sharma', 'priya.sharma@example.com', '9876501234', 1, DATEADD(day, -1, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (2, 'Rahul', 'Verma', 'rahul.verma@example.com', '9876502345', 1, DATEADD(day, -2, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (3, 'Sneha', 'Patel', 'sneha.patel@example.com', '9876503456', 1, DATEADD(day, -1, GETDATE()));
                
                -- Shortlisted (Status = 2) - Candidates being reviewed
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 'Amit', 'Kumar', 'amit.kumar@example.com', '9876504567', 2, DATEADD(day, -5, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (2, 'Neha', 'Singh', 'neha.singh@example.com', '9876505678', 2, DATEADD(day, -4, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 'Vikram', 'Reddy', 'vikram.reddy@example.com', '9876506789', 2, DATEADD(day, -6, GETDATE()));
                
                -- Interviewed (Status = 3) - Completed interviews
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 'Anjali', 'Gupta', 'anjali.gupta@example.com', '9876507890', 3, DATEADD(day, -8, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (3, 'Rohan', 'Mehta', 'rohan.mehta@example.com', '9876508901', 3, DATEADD(day, -7, GETDATE()));
                
                -- Offered (Status = 4) - Job offers extended
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 'Kavya', 'Nair', 'kavya.nair@example.com', '9876509012', 4, DATEADD(day, -10, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (2, 'Arjun', 'Desai', 'arjun.desai@example.com', '9876510123', 4, DATEADD(day, -9, GETDATE()));
                
                -- Hired (Status = 5) - Successfully hired
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 'Divya', 'Iyer', 'divya.iyer@example.com', '9876511234', 5, DATEADD(day, -15, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (2, 'Karthik', 'Rao', 'karthik.rao@example.com', '9876512345', 5, DATEADD(day, -12, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (3, 'Meera', 'Joshi', 'meera.joshi@example.com', '9876513456', 5, DATEADD(day, -14, GETDATE()));
                
                -- Rejected (Status = 0) - Not selected
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (1, 'Sanjay', 'Pillai', 'sanjay.pillai@example.com', '9876514567', 0, DATEADD(day, -6, GETDATE()));
                
                INSERT INTO Candidates (JobId, FirstName, LastName, Email, Mobile, Status, AppliedDate)
                VALUES (2, 'Pooja', 'Menon', 'pooja.menon@example.com', '9876515678', 0, DATEADD(day, -5, GETDATE()));
            ");
        }

        public override void Down()
        {
            Execute.Sql(@"
                DELETE FROM Candidates WHERE Email LIKE '%@example.com' 
                AND CandidateId > 3;
            ");
        }
    }
}
