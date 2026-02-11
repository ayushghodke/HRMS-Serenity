using System.Collections.Generic;

namespace HRMS.Common;

public class DashboardPageModel
{
    public int TotalEmployees { get; set; }
    public int TodayAttendance { get; set; }
    public int PendingLeaves { get; set; }
    public int ActiveTasks { get; set; }

    // Employee Growth Chart Data (Last 12 months)
    public List<string> EmployeeGrowthLabels { get; set; } = new();
    public List<int> EmployeeGrowthData { get; set; } = new();

    // Department Distribution Chart Data
    public List<string> DepartmentLabels { get; set; } = new();
    public List<int> DepartmentCounts { get; set; } = new();

    // Attendance Trend Chart Data (Last 30 days)
    public List<string> AttendanceTrendLabels { get; set; } = new();
    public List<int> AttendanceTrendData { get; set; } = new();

    // Additional metrics
    public int TotalDepartments { get; set; }
    public double AverageAttendanceRate { get; set; }

    // Notices
    public List<HRMS.Communication.NoticeRow> ActiveNotices { get; set; } = new();
}