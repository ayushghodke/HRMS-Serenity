ALTER TABLE [Payroll] ADD [Status] INT NOT NULL DEFAULT 1;
ALTER TABLE [Payroll] ADD [PaymentDate] DATETIME NULL;
ALTER TABLE [Payroll] ADD [PaymentMode] INT NULL;
ALTER TABLE [Payroll] ADD [ProcessedBy] INT NULL;
ALTER TABLE [Payroll] ADD [ApprovedBy] INT NULL;

GO
