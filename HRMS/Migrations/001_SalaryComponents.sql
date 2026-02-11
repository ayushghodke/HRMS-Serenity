-- =============================================
-- Payroll Phase 1 Migration Script
-- Step 1: SalaryComponents Table
-- =============================================

-- Create SalaryComponents table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SalaryComponents')
BEGIN
    CREATE TABLE SalaryComponents (
        ComponentId INT PRIMARY KEY IDENTITY(1,1),
        ComponentName NVARCHAR(100) NOT NULL,
        ComponentType INT NOT NULL, -- 1=Earning, 2=Deduction
        CalculationType INT NOT NULL, -- 1=Fixed, 2=Percentage, 3=Formula
        PercentageOf INT NULL, -- FK to ComponentId (for percentage calculations)
        IsStatutory BIT NOT NULL DEFAULT 0, -- Tax, PF, etc.
        IsTaxable BIT NOT NULL DEFAULT 1,
        IsActive BIT NOT NULL DEFAULT 1,
        DisplayOrder INT NULL,
        Description NVARCHAR(500) NULL,
        CONSTRAINT FK_SalaryComponents_PercentageOf 
            FOREIGN KEY (PercentageOf) REFERENCES SalaryComponents(ComponentId)
    );
    
    PRINT 'SalaryComponents table created successfully.';
END
ELSE
BEGIN
    PRINT 'SalaryComponents table already exists.';
END
GO

-- Add indexes for better performance
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_SalaryComponents_ComponentType')
BEGIN
    CREATE INDEX IX_SalaryComponents_ComponentType ON SalaryComponents(ComponentType);
    PRINT 'Index IX_SalaryComponents_ComponentType created.';
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_SalaryComponents_IsActive')
BEGIN
    CREATE INDEX IX_SalaryComponents_IsActive ON SalaryComponents(IsActive);
    PRINT 'Index IX_SalaryComponents_IsActive created.';
END
GO

-- Insert sample salary components
IF NOT EXISTS (SELECT * FROM SalaryComponents WHERE ComponentName = 'Basic Salary')
BEGIN
    INSERT INTO SalaryComponents (ComponentName, ComponentType, CalculationType, IsStatutory, IsTaxable, IsActive, DisplayOrder, Description)
    VALUES 
        -- Earnings
        ('Basic Salary', 1, 1, 0, 1, 1, 1, 'Base salary component'),
        ('HRA (House Rent Allowance)', 1, 2, 0, 1, 1, 2, '40% of Basic Salary'),
        ('DA (Dearness Allowance)', 1, 2, 0, 1, 1, 3, 'Percentage of Basic Salary'),
        ('Conveyance Allowance', 1, 1, 0, 1, 1, 4, 'Fixed transportation allowance'),
        ('Medical Allowance', 1, 1, 0, 1, 1, 5, 'Fixed medical allowance'),
        ('Special Allowance', 1, 1, 0, 1, 1, 6, 'Additional allowance as per grade'),
        
        -- Deductions
        ('PF (Provident Fund)', 2, 2, 1, 0, 1, 101, '12% of Basic Salary'),
        ('Professional Tax', 2, 1, 1, 0, 1, 102, 'Fixed professional tax deduction'),
        ('Income Tax (TDS)', 2, 1, 1, 0, 1, 103, 'Tax deducted at source'),
        ('ESI (Employee State Insurance)', 2, 2, 1, 0, 1, 104, '0.75% of Gross Salary');

    PRINT 'Sample salary components inserted successfully.';
    
    -- Update percentage-based components to link to Basic Salary
    DECLARE @BasicSalaryId INT;
    SELECT @BasicSalaryId = ComponentId FROM SalaryComponents WHERE ComponentName = 'Basic Salary';
    
    UPDATE SalaryComponents 
    SET PercentageOf = @BasicSalaryId 
    WHERE ComponentName IN ('HRA (House Rent Allowance)', 'DA (Dearness Allowance)', 'PF (Provident Fund)');
    
    PRINT 'Percentage-based components linked to Basic Salary.';
END
ELSE
BEGIN
    PRINT 'Sample salary components already exist.';
END
GO

PRINT '============================================='
PRINT 'SalaryComponents migration completed!'
PRINT '============================================='
