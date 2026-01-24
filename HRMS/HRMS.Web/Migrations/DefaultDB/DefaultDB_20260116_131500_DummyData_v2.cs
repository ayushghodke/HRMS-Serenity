using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260116_131500)]
public class DefaultDB_20260116_131500_DummyData_v2 : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            -- Clear existing dummy data (from previous migration attempt)
            DELETE FROM Attendance;
            DELETE FROM Leaves;
            DELETE FROM Tasks;
            DELETE FROM Payroll;
            DELETE FROM Employees;
            DELETE FROM Designations;
            DELETE FROM Departments;

            -- Departments
            SET IDENTITY_INSERT Departments ON;
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (1, 'Information Technology', 'Software and Hardware support', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (2, 'Human Resources', 'People and Culture', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (3, 'Marketing', 'Brand and Campaign', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (4, 'Sales', 'Revenue Generation', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (5, 'Finance', 'Accounts and Payroll processing', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (6, 'Operations', 'Daily business operations', 1);
            SET IDENTITY_INSERT Departments OFF;

            -- Designations
            SET IDENTITY_INSERT Designations ON;
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (1, 'Senior Developer', 1, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (2, 'Project Manager', 2, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (3, 'HR Manager', 2, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (4, 'Marketing Associate', 1, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (5, 'CTO', 3, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (6, 'QA Engineer', 1, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (7, 'UI/UX Designer', 1, 1);
            SET IDENTITY_INSERT Designations OFF;

            -- Employees
            SET IDENTITY_INSERT Employees ON;
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (1, 'EMP001', 'John', 'Doe', 'john.doe@example.com', 1, 1, '2023-01-15', 1, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (2, 'EMP002', 'Jane', 'Smith', 'jane.smith@example.com', 2, 3, '2023-02-20', 1, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (3, 'EMP003', 'Michael', 'Brown', 'michael.brown@example.com', 1, 2, '2023-03-10', 1, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (4, 'EMP004', 'Sarah', 'Wilson', 'sarah.wilson@example.com', 3, 4, '2023-05-01', 2, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (5, 'EMP005', 'Robert', 'Taylor', 'robert.t@example.com', 1, 5, '2022-11-01', 1, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (6, 'EMP006', 'Emily', 'Davis', 'emily.d@example.com', 1, 6, '2023-06-15', 1, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (7, 'EMP007', 'David', 'Miller', 'david.m@example.com', 1, 7, '2023-07-20', 1, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (8, 'EMP008', 'Lisa', 'Anderson', 'lisa.a@example.com', 4, 4, '2023-08-05', 1, 1);
            SET IDENTITY_INSERT Employees OFF;

            -- Attendance (Today)
            INSERT INTO Attendance (UserId, Name, DateNTime, Type, Coordinates, Location, PunchIn, Distance)
            VALUES ('EMP001', 1, GETDATE(), 1, '28.6139, 77.2090', 'Main Office', GETDATE(), 0.0);
            INSERT INTO Attendance (UserId, Name, DateNTime, Type, Coordinates, Location, PunchIn, Distance)
            VALUES ('EMP002', 1, GETDATE(), 1, '28.6139, 77.2090', 'Main Office', GETDATE(), 0.0);
            INSERT INTO Attendance (UserId, Name, DateNTime, Type, Coordinates, Location, PunchIn, Distance)
            VALUES ('EMP003', 1, GETDATE(), 1, '28.6139, 77.2090', 'Main Office', GETDATE(), 0.0);
            INSERT INTO Attendance (UserId, Name, DateNTime, Type, Coordinates, Location, PunchIn, Distance)
            VALUES ('EMP006', 1, GETDATE(), 1, '28.6139, 77.2090', 'Main Office', GETDATE(), 0.0);

            -- Leaves
            INSERT INTO Leaves (EmployeeId, LeaveType, StartDate, EndDate, TotalDays, Reason, Status, CreatedDate)
            VALUES (1, 1, DATEADD(day, 5, GETDATE()), DATEADD(day, 7, GETDATE()), 3.0, 'Family function', 0, GETDATE());
            INSERT INTO Leaves (EmployeeId, LeaveType, StartDate, EndDate, TotalDays, Reason, Status, CreatedDate)
            VALUES (2, 2, DATEADD(day, -10, GETDATE()), DATEADD(day, -8, GETDATE()), 3.0, 'Sick leave', 1, DATEADD(day, -12, GETDATE()));
            INSERT INTO Leaves (EmployeeId, LeaveType, StartDate, EndDate, TotalDays, Reason, Status, CreatedDate)
            VALUES (4, 1, DATEADD(day, 2, GETDATE()), DATEADD(day, 3, GETDATE()), 2.0, 'Personal work', 2, GETDATE());

            -- Tasks
            INSERT INTO Tasks (Title, Description, AssignedTo, DueDate, Status)
            VALUES ('Finalize Q4 Budget', 'Collaborate with Finance team', 3, DATEADD(day, 5, GETDATE()), 0);
            INSERT INTO Tasks (Title, Description, AssignedTo, DueDate, Status)
            VALUES ('Complete HRMS Polish', 'Fix UI alignment and dummy data', 1, DATEADD(day, 1, GETDATE()), 1);
            INSERT INTO Tasks (Title, Description, AssignedTo, DueDate, Status)
            VALUES ('New Hire Onboarding', 'Onboard 3 new developers', 2, DATEADD(day, 3, GETDATE()), 1);
            INSERT INTO Tasks (Title, Description, AssignedTo, DueDate, Status)
            VALUES ('Server Migration', 'Move production to new cluster', 5, DATEADD(day, -2, GETDATE()), 2);
            INSERT INTO Tasks (Title, Description, AssignedTo, DueDate, Status)
            VALUES ('API Documentation', 'Update Swagger docs for v2', 6, DATEADD(day, 10, GETDATE()), 0);

            -- Payroll (Last 2 Months)
            INSERT INTO Payroll (EmployeeId, Month, Year, BasicSalary, Allowances, Deductions, NetSalary, GeneratedDate)
            VALUES (1, 12, 2025, 60000, 5000, 2000, 63000, '2025-12-31');
            INSERT INTO Payroll (EmployeeId, Month, Year, BasicSalary, Allowances, Deductions, NetSalary, GeneratedDate)
            VALUES (2, 12, 2025, 55000, 4000, 1500, 57500, '2025-12-31');
            INSERT INTO Payroll (EmployeeId, Month, Year, BasicSalary, Allowances, Deductions, NetSalary, GeneratedDate)
            VALUES (3, 12, 2025, 50000, 3000, 1000, 52000, '2025-12-31');
            INSERT INTO Payroll (EmployeeId, Month, Year, BasicSalary, Allowances, Deductions, NetSalary, GeneratedDate)
            VALUES (1, 11, 2025, 60000, 5000, 2000, 63000, '2025-11-30');
            INSERT INTO Payroll (EmployeeId, Month, Year, BasicSalary, Allowances, Deductions, NetSalary, GeneratedDate)
            VALUES (5, 12, 2025, 120000, 10000, 5000, 125000, '2025-12-31');
        ");
    }

    public override void Down()
    {
    }
}
