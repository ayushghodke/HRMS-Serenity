using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Web;
using System;
using System.Linq;
using HRMS.HR;
using HRMS.Operations;

namespace HRMS.Common.Pages;

[Route("Dashboard/[action]")]
public class DashboardPage : Controller
{
    [PageAuthorize, HttpGet, Route("~/")]
    public ActionResult Index([FromServices] ITwoLevelCache cache, [FromServices] ISqlConnections sqlConnections)
    {
        var model = cache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
            EmployeeRow.Fields.GenerationKey, () =>
            {
                var m = new DashboardPageModel();
                using (var connection = sqlConnections.NewFor<EmployeeRow>())
                {
                    // Basic Stats
                    m.TotalEmployees = connection.Count<EmployeeRow>();
                    m.PendingLeaves = connection.Count<LeaveRow>(LeaveRow.Fields.Status == (int)LeaveStatus.Pending);
                    m.ActiveTasks = connection.Count<TaskRow>(TaskRow.Fields.Status == (int)HRMS.Operations.TaskStatus.In_Progress);
                    m.TodayAttendance = connection.Count<AttendanceRow>(AttendanceRow.Fields.DateNTime >= DateTime.Today);

                    // Employee Growth Data (Last 12 months)
                    var monthlyEmployees = connection.Query<dynamic>(@"
                        WITH MonthlyData AS (
                            SELECT 
                                YEAR(JoiningDate) AS Yr,
                                MONTH(JoiningDate) AS Mn,
                                COUNT(*) AS Count
                            FROM Employees
                            WHERE JoiningDate >= DATEADD(MONTH, -12, GETDATE())
                            GROUP BY YEAR(JoiningDate), MONTH(JoiningDate)
                        )
                        SELECT 
                            DATENAME(MONTH, DATEFROMPARTS(Yr, Mn, 1)) + ' ' + CAST(Yr AS VARCHAR) AS Month,
                            Count
                        FROM MonthlyData
                        ORDER BY Yr, Mn
                    ").ToList();

                    foreach (var item in monthlyEmployees)
                    {
                        m.EmployeeGrowthLabels.Add(item.Month);
                        m.EmployeeGrowthData.Add((int)item.Count);
                    }

                    // Department Distribution
                    var departmentStats = connection.Query<dynamic>(@"
                        SELECT 
                            d.DepartmentName,
                            COUNT(e.EmployeeId) AS Count
                        FROM Departments d
                        LEFT JOIN Employees e ON e.DepartmentId = d.DepartmentId
                        WHERE d.IsActive = 1
                        GROUP BY d.DepartmentName
                        HAVING COUNT(e.EmployeeId) > 0
                        ORDER BY COUNT(e.EmployeeId) DESC
                    ").ToList();

                    foreach (var dept in departmentStats)
                    {
                        m.DepartmentLabels.Add(dept.DepartmentName);
                        m.DepartmentCounts.Add((int)dept.Count);
                    }

                    // Attendance Trend (Last 30 days)
                    var attendanceTrend = connection.Query<dynamic>(@"
                        WITH DailyAttendance AS (
                            SELECT 
                                CAST(DateNTime AS DATE) AS AttDate,
                                COUNT(DISTINCT Name) AS Count
                            FROM Attendance
                            WHERE DateNTime >= DATEADD(DAY, -30, GETDATE())
                            GROUP BY CAST(DateNTime AS DATE)
                        )
                        SELECT 
                            FORMAT(AttDate, 'MMM dd') AS Date,
                            Count
                        FROM DailyAttendance
                        ORDER BY AttDate
                    ").ToList();

                    foreach (var day in attendanceTrend)
                    {
                        m.AttendanceTrendLabels.Add(day.Date);
                        m.AttendanceTrendData.Add((int)day.Count);
                    }

                    // Additional metrics
                    m.TotalDepartments = connection.Count<DepartmentRow>(DepartmentRow.Fields.IsActive == 1);
                    
                    var totalWorkingDays = attendanceTrend.Count > 0 ? attendanceTrend.Count : 1;
                    var totalPossibleAttendance = m.TotalEmployees * totalWorkingDays;
                    var actualAttendance = m.AttendanceTrendData.Sum();
                    m.AverageAttendanceRate = totalPossibleAttendance > 0 
                        ? Math.Round((double)actualAttendance / totalPossibleAttendance * 100, 2) 
                        : 0;

                    // Fetch Active Notices
                    m.ActiveNotices = connection.List<HRMS.Communication.NoticeRow>(q => q
                        .SelectTableFields()
                        .Where(HRMS.Communication.NoticeRow.Fields.IsActive == 1)
                        .Where(HRMS.Communication.NoticeRow.Fields.PublishDate <= DateTime.Now)
                        .Where(HRMS.Communication.NoticeRow.Fields.ExpiryDate >= DateTime.Now || HRMS.Communication.NoticeRow.Fields.ExpiryDate.IsNull())
                        .OrderBy(HRMS.Communication.NoticeRow.Fields.Priority, desc: true)
                        .OrderBy(HRMS.Communication.NoticeRow.Fields.PublishDate, desc: true));
                }
                return m;
            });

        return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
    }
}
