CREATE TABLE EmployeeSalary (
    EmployeeSalaryId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT NOT NULL,
    GradeId INT NULL,
    EffectiveDate DATETIME NOT NULL,
    BasicSalary DECIMAL(18,2) NOT NULL,
    GrossSalary DECIMAL(18,2) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    FOREIGN KEY (GradeId) REFERENCES SalaryGrades(GradeId)
);

CREATE TABLE EmployeeSalaryDetails (
    DetailId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeSalaryId INT NOT NULL,
    ComponentId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (EmployeeSalaryId) REFERENCES EmployeeSalary(EmployeeSalaryId),
    FOREIGN KEY (ComponentId) REFERENCES SalaryComponents(ComponentId)
);

CREATE INDEX IX_EmployeeSalary_EmployeeId ON EmployeeSalary(EmployeeId);
CREATE INDEX IX_EmployeeSalary_EffectiveDate ON EmployeeSalary(EffectiveDate);
