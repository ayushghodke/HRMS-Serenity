using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;

namespace HRMS.Operations;

[Report("Operations.LeaveHistory")]
[ReportDesign("~/Modules/Operations/LeaveReports/LeaveHistoryReport.cshtml")]
[RequiredPermission("Operations:Leave")]
public class LeaveHistoryReport : BaseReport
{
    private readonly ISqlConnections sqlConnections;

    public LeaveHistoryReport(ISqlConnections sqlConnections)
    {
        this.sqlConnections = sqlConnections;
    }

    public override object GetData()
    {
        using var connection = sqlConnections.NewByKey("Default");

        var sql = @"
            SELECT
                l.LeaveApplicationNo,
                (e.FirstName + ' ' + e.LastName) AS EmployeeName,
                d.DepartmentName,
                lt.LeaveTypeName,
                l.StartDate,
                l.EndDate,
                ISNULL(l.TotalDays, 0) AS TotalDays,
                ISNULL(l.PaidDays, 0) AS PaidDays,
                ISNULL(l.UnpaidDays, 0) AS UnpaidDays,
                ISNULL(l.FinalStatus, 0) AS FinalStatus
            FROM Leaves l
            INNER JOIN Employees e ON e.EmployeeId = l.EmployeeId
            LEFT JOIN Departments d ON d.DepartmentId = e.DepartmentId
            LEFT JOIN LeaveTypes lt ON lt.LeaveTypeId = l.LeaveTypeId
            ORDER BY l.ApplicationDate DESC, l.LeaveId DESC
        ";

        return connection.Query<LeaveReportRow>(sql).ToList();
    }
}
