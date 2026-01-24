using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260116_130000)]
public class DefaultDB_20260116_130000_DummyData : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            DELETE FROM Attendance;
            DELETE FROM Leaves;
            DELETE FROM Tasks;
            DELETE FROM Payroll;
            DELETE FROM Employees;
            DELETE FROM Designations;
            DELETE FROM Departments;

            SET IDENTITY_INSERT Departments ON;
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (1, 'Information Technology', 'Software and Hardware support', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (2, 'Human Resources', 'People and Culture', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (3, 'Marketing', 'Brand and Campaign', 1);
            INSERT INTO Departments (DepartmentId, DepartmentName, Description, IsActive) VALUES (4, 'Sales', 'Revenue Generation', 1);
            SET IDENTITY_INSERT Departments OFF;

            SET IDENTITY_INSERT Designations ON;
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (1, 'Senior Developer', 1, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (2, 'Project Manager', 2, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (3, 'HR Manager', 2, 1);
            INSERT INTO Designations (DesignationId, DesignationName, Level, IsActive) VALUES (4, 'Marketing Associate', 1, 1);
            SET IDENTITY_INSERT Designations OFF;

            SET IDENTITY_INSERT Employees ON;
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (1, 'EMP001', 'John', 'Doe', 'john.doe@example.com', 1, 1, '2023-01-15', 1, 1);
            INSERT INTO Employees (EmployeeId, EmployeeCode, FirstName, LastName, Email, DepartmentId, DesignationId, JoiningDate, EmploymentType, Status) 
            VALUES (2, 'EMP002', 'Jane', 'Smith', 'jane.smith@example.com', 2, 3, '2023-02-20', 1, 1);
            SET IDENTITY_INSERT Employees OFF;

            INSERT INTO Attendance (UserId, Name, DateNTime, Type, Coordinates, Location, PunchIn, Distance)
            VALUES ('EMP001', 1, GETDATE(), 1, '28.6139, 77.2090', 'Main Office', GETDATE(), 0.0);

            INSERT INTO Tasks (Title, Description, AssignedTo, DueDate, Status)
            VALUES ('Complete HRMS Migration', 'Add seed data and polish UI', 1, DATEADD(day, 2, GETDATE()), 1);

            INSERT INTO Payroll (EmployeeId, Month, Year, BasicSalary, Allowances, Deductions, NetSalary, GeneratedDate)
            VALUES (1, 12, 2025, 50000, 5000, 2000, 53000, GETDATE());
        ");
    }

    public override void Down()
    {
    }
}
