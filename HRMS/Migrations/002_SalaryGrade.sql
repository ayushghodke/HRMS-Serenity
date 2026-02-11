CREATE TABLE SalaryGrades (
    GradeId INT PRIMARY KEY IDENTITY(1,1),
    GradeName NVARCHAR(100) NOT NULL,
    GradeCode NVARCHAR(50),
    MinSalary DECIMAL(18,2) NULL,
    MaxSalary DECIMAL(18,2) NULL,
    Description NVARCHAR(500) NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

INSERT INTO SalaryGrades (GradeName, GradeCode, MinSalary, MaxSalary, Description, IsActive)
VALUES 
    ('Executive', 'GR-A', 50000.00, 100000.00, 'Senior Management', 1),
    ('Senior Manager', 'GR-B', 30000.00, 60000.00, 'Department Heads', 1),
    ('Manager', 'GR-C', 20000.00, 40000.00, 'Team Managers', 1),
    ('Team Lead', 'GR-D', 15000.00, 30000.00, 'Team Leads', 1),
    ('Staff', 'GR-E', 10000.00, 20000.00, 'General Staff', 1);

CREATE INDEX IX_SalaryGrades_GradeName ON SalaryGrades(GradeName);
