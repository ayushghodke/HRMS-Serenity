using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260216_103000)]
public class DefaultDB_20260216_103000_LeaveModuleDummyData : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            IF NOT EXISTS (SELECT 1 FROM LeaveTypes WHERE LeaveCode = 'CL')
            BEGIN
                INSERT INTO LeaveTypes
                (
                    LeaveTypeName, LeaveCode, LeaveCategory, AnnualAllocation,
                    MonthlyAccrual, CarryForwardAllowed, MaxCarryForwardDays,
                    EncashmentAllowed, GenderSpecific, ProbationApplicable,
                    MinimumServiceRequiredMonths, MaxLeavePerRequest,
                    SandwichRuleApplicable, HalfDayAllowed, DocumentsRequired, Status
                )
                VALUES
                (
                    'Casual Leave', 'CL', 1, 12,
                    1, 1, 6,
                    0, 0, 1,
                    0, 3,
                    0, 1, 0, 1
                );
            END;

            IF NOT EXISTS (SELECT 1 FROM LeaveTypes WHERE LeaveCode = 'SL')
            BEGIN
                INSERT INTO LeaveTypes
                (
                    LeaveTypeName, LeaveCode, LeaveCategory, AnnualAllocation,
                    MonthlyAccrual, CarryForwardAllowed, MaxCarryForwardDays,
                    EncashmentAllowed, GenderSpecific, ProbationApplicable,
                    MinimumServiceRequiredMonths, MaxLeavePerRequest,
                    SandwichRuleApplicable, HalfDayAllowed, DocumentsRequired, Status
                )
                VALUES
                (
                    'Sick Leave', 'SL', 1, 10,
                    0, 1, 10,
                    0, 0, 1,
                    0, 10,
                    0, 1, 1, 1
                );
            END;

            IF NOT EXISTS (SELECT 1 FROM LeaveTypes WHERE LeaveCode = 'EL')
            BEGIN
                INSERT INTO LeaveTypes
                (
                    LeaveTypeName, LeaveCode, LeaveCategory, AnnualAllocation,
                    MonthlyAccrual, CarryForwardAllowed, MaxCarryForwardDays,
                    EncashmentAllowed, GenderSpecific, ProbationApplicable,
                    MinimumServiceRequiredMonths, MaxLeavePerRequest,
                    SandwichRuleApplicable, HalfDayAllowed, DocumentsRequired, Status
                )
                VALUES
                (
                    'Earned Leave', 'EL', 1, 15,
                    1, 1, 10,
                    1, 0, 0,
                    6, 15,
                    1, 1, 0, 1
                );
            END;

            IF NOT EXISTS (SELECT 1 FROM LeaveTypes WHERE LeaveCode = 'LWP')
            BEGIN
                INSERT INTO LeaveTypes
                (
                    LeaveTypeName, LeaveCode, LeaveCategory, AnnualAllocation,
                    MonthlyAccrual, CarryForwardAllowed, MaxCarryForwardDays,
                    EncashmentAllowed, GenderSpecific, ProbationApplicable,
                    MinimumServiceRequiredMonths, MaxLeavePerRequest,
                    SandwichRuleApplicable, HalfDayAllowed, DocumentsRequired, Status
                )
                VALUES
                (
                    'Leave Without Pay', 'LWP', 2, 0,
                    0, 0, 0,
                    0, 0, 1,
                    0, 30,
                    0, 1, 0, 1
                );
            END;
        ");

        Execute.Sql(@"
            IF NOT EXISTS (SELECT 1 FROM LeavePolicies WHERE PolicyName = 'Standard Leave Policy 2026')
            BEGIN
                INSERT INTO LeavePolicies
                (
                    PolicyName, ApplicableFromDate, Branch, DepartmentId,
                    MaxConsecutiveLeavesAllowed, NoticePeriodLeaveAllowed,
                    ProbationLeaveAllowed, ApprovalLevels, HROverridePermission,
                    PayrollCutoffDay, Status
                )
                VALUES
                (
                    'Standard Leave Policy 2026', '2026-01-01', 'HQ', NULL,
                    15, 0,
                    1, 2, 1,
                    26, 1
                );
            END;

            INSERT INTO LeavePolicyLeaveTypes (LeavePolicyId, LeaveTypeId)
            SELECT p.LeavePolicyId, lt.LeaveTypeId
            FROM LeavePolicies p
            INNER JOIN LeaveTypes lt ON lt.LeaveCode IN ('CL', 'SL', 'EL', 'LWP')
            WHERE p.PolicyName = 'Standard Leave Policy 2026'
              AND NOT EXISTS
              (
                  SELECT 1
                  FROM LeavePolicyLeaveTypes pl
                  WHERE pl.LeavePolicyId = p.LeavePolicyId
                    AND pl.LeaveTypeId = lt.LeaveTypeId
              );
        ");

        Execute.Sql(@"
            WITH ActiveEmployees AS
            (
                SELECT e.EmployeeId, e.DepartmentId
                FROM Employees e
                WHERE ISNULL(e.Status, 0) = 1
            )
            INSERT INTO EmployeeLeaveProfiles
            (
                EmployeeId, LeavePolicyId, LeaveTypeId,
                OpeningBalance, AccruedLeave, UsedLeave,
                PendingLeave, CarryForwardLeave, LOPDays, LastUpdatedDate
            )
            SELECT
                ae.EmployeeId,
                p.LeavePolicyId,
                lt.LeaveTypeId,
                CASE lt.LeaveCode
                    WHEN 'CL' THEN 2
                    WHEN 'SL' THEN 1
                    WHEN 'EL' THEN 3
                    ELSE 0
                END AS OpeningBalance,
                CASE lt.LeaveCode
                    WHEN 'CL' THEN 4
                    WHEN 'SL' THEN 2
                    WHEN 'EL' THEN 5
                    ELSE 0
                END AS AccruedLeave,
                CASE lt.LeaveCode
                    WHEN 'CL' THEN 1
                    WHEN 'SL' THEN 0.5
                    WHEN 'EL' THEN 2
                    ELSE 1
                END AS UsedLeave,
                CASE lt.LeaveCode
                    WHEN 'CL' THEN 1
                    ELSE 0
                END AS PendingLeave,
                CASE lt.LeaveCode
                    WHEN 'EL' THEN 2
                    ELSE 0
                END AS CarryForwardLeave,
                CASE lt.LeaveCode
                    WHEN 'LWP' THEN 1
                    ELSE 0
                END AS LOPDays,
                GETDATE() AS LastUpdatedDate
            FROM ActiveEmployees ae
            CROSS JOIN LeaveTypes lt
            OUTER APPLY
            (
                SELECT TOP 1 lp.LeavePolicyId
                FROM LeavePolicies lp
                WHERE lp.Status = 1
                  AND (lp.DepartmentId IS NULL OR lp.DepartmentId = ae.DepartmentId)
                ORDER BY CASE WHEN lp.DepartmentId = ae.DepartmentId THEN 0 ELSE 1 END,
                         lp.LeavePolicyId
            ) p
            WHERE lt.LeaveCode IN ('CL', 'SL', 'EL', 'LWP')
              AND NOT EXISTS
              (
                  SELECT 1
                  FROM EmployeeLeaveProfiles ep
                  WHERE ep.EmployeeId = ae.EmployeeId
                    AND ep.LeaveTypeId = lt.LeaveTypeId
              );
        ");

        Execute.Sql(@"
            DECLARE @ApproverUserId INT = (SELECT TOP 1 UserId FROM Users ORDER BY UserId);

            ;WITH RankedEmployees AS
            (
                SELECT
                    e.EmployeeId,
                    e.ManagerId,
                    ROW_NUMBER() OVER (ORDER BY e.EmployeeId) AS rn
                FROM Employees e
                WHERE ISNULL(e.Status, 0) = 1
            )
            INSERT INTO Leaves
            (
                EmployeeId, LeaveType, LeaveTypeId, LeaveApplicationNo, ApplicationDate,
                StartDate, EndDate, HalfDaySession, TotalDays, PaidDays, UnpaidDays,
                Reason, Status, HrApprovalStatus, FinalStatus, ReportingManagerId,
                ContactDuringLeave, CreatedByUserId, ApprovedBy, ApprovedDate, CreatedDate
            )
            SELECT
                d.EmployeeId,
                d.LeaveType,
                d.LeaveTypeId,
                d.LeaveApplicationNo,
                d.ApplicationDate,
                d.StartDate,
                d.EndDate,
                d.HalfDaySession,
                d.TotalDays,
                d.PaidDays,
                d.UnpaidDays,
                d.Reason,
                d.Status,
                d.HrApprovalStatus,
                d.FinalStatus,
                COALESCE(d.ReportingManagerId, d.EmployeeId),
                '9999999999',
                @ApproverUserId,
                CASE WHEN d.FinalStatus IN (1, 2) THEN @ApproverUserId ELSE NULL END,
                CASE WHEN d.FinalStatus IN (1, 2) THEN DATEADD(day, -1, GETDATE()) ELSE NULL END,
                DATEADD(day, -3, GETDATE())
            FROM
            (
                SELECT re.EmployeeId, re.ManagerId AS ReportingManagerId,
                       cl.LeaveTypeId,
                       1 AS LeaveType,
                       'LV-2026-0001' AS LeaveApplicationNo,
                       DATEADD(day, -10, GETDATE()) AS ApplicationDate,
                       DATEADD(day, -2, GETDATE()) AS StartDate,
                       DATEADD(day, 1, GETDATE()) AS EndDate,
                       NULL AS HalfDaySession,
                       CAST(4.0 AS FLOAT) AS TotalDays,
                       CAST(4.0 AS DECIMAL(5, 2)) AS PaidDays,
                       CAST(0.0 AS DECIMAL(5, 2)) AS UnpaidDays,
                       'Family travel' AS Reason,
                       1 AS Status,
                       1 AS HrApprovalStatus,
                       2 AS FinalStatus
                FROM RankedEmployees re
                CROSS JOIN (SELECT TOP 1 LeaveTypeId FROM LeaveTypes WHERE LeaveCode = 'CL' ORDER BY LeaveTypeId) cl
                WHERE re.rn = 1

                UNION ALL

                SELECT re.EmployeeId, re.ManagerId,
                       sl.LeaveTypeId,
                       1,
                       'LV-2026-0002',
                       DATEADD(day, -20, GETDATE()),
                       DATEADD(day, -15, GETDATE()),
                       DATEADD(day, -14, GETDATE()),
                       NULL,
                       CAST(2.0 AS FLOAT),
                       CAST(2.0 AS DECIMAL(5, 2)),
                       CAST(0.0 AS DECIMAL(5, 2)),
                       'Fever and rest',
                       1,
                       1,
                       2
                FROM RankedEmployees re
                CROSS JOIN (SELECT TOP 1 LeaveTypeId FROM LeaveTypes WHERE LeaveCode = 'SL' ORDER BY LeaveTypeId) sl
                WHERE re.rn = 2

                UNION ALL

                SELECT re.EmployeeId, re.ManagerId,
                       el.LeaveTypeId,
                       1,
                       'LV-2026-0003',
                       DATEADD(day, -5, GETDATE()),
                       DATEADD(day, 2, GETDATE()),
                       DATEADD(day, 4, GETDATE()),
                       NULL,
                       CAST(3.0 AS FLOAT),
                       CAST(3.0 AS DECIMAL(5, 2)),
                       CAST(0.0 AS DECIMAL(5, 2)),
                       'Personal work',
                       0,
                       0,
                       0
                FROM RankedEmployees re
                CROSS JOIN (SELECT TOP 1 LeaveTypeId FROM LeaveTypes WHERE LeaveCode = 'EL' ORDER BY LeaveTypeId) el
                WHERE re.rn = 3

                UNION ALL

                SELECT re.EmployeeId, re.ManagerId,
                       cl.LeaveTypeId,
                       1,
                       'LV-2026-0004',
                       DATEADD(day, -1, GETDATE()),
                       DATEADD(day, 5, GETDATE()),
                       DATEADD(day, 6, GETDATE()),
                       NULL,
                       CAST(2.0 AS FLOAT),
                       CAST(2.0 AS DECIMAL(5, 2)),
                       CAST(0.0 AS DECIMAL(5, 2)),
                       'Festival visit',
                       0,
                       0,
                       0
                FROM RankedEmployees re
                CROSS JOIN (SELECT TOP 1 LeaveTypeId FROM LeaveTypes WHERE LeaveCode = 'CL' ORDER BY LeaveTypeId) cl
                WHERE re.rn = 4

                UNION ALL

                SELECT re.EmployeeId, re.ManagerId,
                       lwp.LeaveTypeId,
                       2,
                       'LV-2026-0005',
                       DATEADD(day, -8, GETDATE()),
                       DATEADD(day, 7, GETDATE()),
                       DATEADD(day, 8, GETDATE()),
                       NULL,
                       CAST(2.0 AS FLOAT),
                       CAST(0.0 AS DECIMAL(5, 2)),
                       CAST(2.0 AS DECIMAL(5, 2)),
                       'Urgent personal commitment',
                       1,
                       1,
                       1
                FROM RankedEmployees re
                CROSS JOIN (SELECT TOP 1 LeaveTypeId FROM LeaveTypes WHERE LeaveCode = 'LWP' ORDER BY LeaveTypeId) lwp
                WHERE re.rn = 5

                UNION ALL

                SELECT re.EmployeeId, re.ManagerId,
                       el.LeaveTypeId,
                       1,
                       'LV-2026-0006',
                       DATEADD(day, -40, GETDATE()),
                       DATEADD(day, -35, GETDATE()),
                       DATEADD(day, -33, GETDATE()),
                       NULL,
                       CAST(3.0 AS FLOAT),
                       CAST(3.0 AS DECIMAL(5, 2)),
                       CAST(0.0 AS DECIMAL(5, 2)),
                       'Vacation',
                       1,
                       1,
                       2
                FROM RankedEmployees re
                CROSS JOIN (SELECT TOP 1 LeaveTypeId FROM LeaveTypes WHERE LeaveCode = 'EL' ORDER BY LeaveTypeId) el
                WHERE re.rn = 1
            ) d
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM Leaves l
                WHERE l.LeaveApplicationNo = d.LeaveApplicationNo
            );
        ");

        Execute.Sql(@"
            DECLARE @ApproverUserId INT = (SELECT TOP 1 UserId FROM Users ORDER BY UserId);

            IF @ApproverUserId IS NOT NULL
            BEGIN
                INSERT INTO LeaveApprovals
                (
                    LeaveId, ApproverId, ApprovalLevel, ApprovalDate,
                    Status, Remarks, EscalationTrigger, EscalationTo, TimeStamp
                )
                SELECT
                    l.LeaveId,
                    @ApproverUserId,
                    1,
                    DATEADD(hour, -8, GETDATE()),
                    CASE WHEN l.FinalStatus = 0 THEN 0 WHEN l.FinalStatus < 0 THEN -1 ELSE 1 END,
                    CASE WHEN l.FinalStatus = 0 THEN 'Pending manager action.' ELSE 'Reviewed at level 1.' END,
                    0,
                    NULL,
                    GETDATE()
                FROM Leaves l
                WHERE l.LeaveApplicationNo IN ('LV-2026-0001', 'LV-2026-0002', 'LV-2026-0005', 'LV-2026-0006')
                  AND NOT EXISTS
                  (
                      SELECT 1
                      FROM LeaveApprovals la
                      WHERE la.LeaveId = l.LeaveId
                        AND la.ApprovalLevel = 1
                  );

                INSERT INTO LeaveApprovals
                (
                    LeaveId, ApproverId, ApprovalLevel, ApprovalDate,
                    Status, Remarks, EscalationTrigger, EscalationTo, TimeStamp
                )
                SELECT
                    l.LeaveId,
                    @ApproverUserId,
                    2,
                    DATEADD(hour, -3, GETDATE()),
                    CASE WHEN l.FinalStatus = 2 THEN 1 WHEN l.FinalStatus < 0 THEN -1 ELSE 0 END,
                    CASE WHEN l.FinalStatus = 2 THEN 'Final approval completed.' ELSE 'Awaiting HR final review.' END,
                    0,
                    NULL,
                    GETDATE()
                FROM Leaves l
                WHERE l.LeaveApplicationNo IN ('LV-2026-0001', 'LV-2026-0002', 'LV-2026-0005', 'LV-2026-0006')
                  AND NOT EXISTS
                  (
                      SELECT 1
                      FROM LeaveApprovals la
                      WHERE la.LeaveId = l.LeaveId
                        AND la.ApprovalLevel = 2
                  );
            END;
        ");
    }

    public override void Down()
    {
    }
}
