using Serenity.Navigation;
using MyPages = HRMS.Operations.Pages;

[assembly: NavigationMenu(2000, "Operations", icon: "fa-cogs")]
[assembly: NavigationLink(2000, "Operations/Attendance", typeof(MyPages.AttendancePage), icon: "fa-clock-o")]

// Payroll Submenu  
[assembly: NavigationMenu(2001, "Operations/Payroll", icon: "fa-money")]
[assembly: NavigationLink(2002, "Operations/Payroll/Payroll Records", typeof(MyPages.PayrollPage), icon: "fa-file-text-o")]
[assembly: NavigationLink(2003, "Operations/Payroll/Salary Components", typeof(MyPages.SalaryComponentsPage), icon: "fa-list")]
[assembly: NavigationLink(2004, "Operations/Payroll/Salary Grade", typeof(MyPages.SalaryGradePage), icon: "fa-graduation-cap")]

[assembly: NavigationLink(2010, "Operations/Tasks", typeof(MyPages.TaskPage), icon: "fa-tasks")]
[assembly: NavigationLink(2011, "Operations/Task Kanban", typeof(MyPages.TaskKanbanPage), icon: "fa-trello")]
[assembly: NavigationLink(2012, "Operations/Assets", typeof(MyPages.AssetsPage), icon: "fa-cubes")]
[assembly: NavigationLink(2013, "Operations/Asset Kanban", typeof(MyPages.AssetKanbanPage), icon: "fa-th-large")]

// Leave Management Submenu
[assembly: NavigationMenu(2100, "Operations/Leave Management", icon: "fa-calendar-check-o")]
[assembly: NavigationLink(2100, "Operations/Leave Management/Leave Types", typeof(MyPages.LeaveTypePage), icon: "fa-tags")]
[assembly: NavigationLink(2100, "Operations/Leave Management/Holidays", typeof(MyPages.HolidayPage), icon: "fa-calendar-o")]
[assembly: NavigationLink(2100, "Operations/Leave Management/Leave Policies", typeof(MyPages.LeavePolicyPage), icon: "fa-shield")]
[assembly: NavigationLink(2100, "Operations/Leave Management/Employee Leave Profiles", typeof(MyPages.EmployeeLeaveProfilePage), icon: "fa-id-badge")]
[assembly: NavigationLink(2101, "Operations/Leave Management/Leave Requests", typeof(MyPages.LeavePage), icon: "fa-calendar-minus-o")]
[assembly: NavigationLink(2101, "Operations/Leave Management/Leave Kanban", typeof(MyPages.LeaveKanbanPage), icon: "fa-columns")]
[assembly: NavigationLink(2101, "Operations/Leave Management/Leave Approvals", typeof(MyPages.LeaveApprovalPage), icon: "fa-check-square-o")]
[assembly: NavigationLink(2102, "Operations/Leave Management/Leave Balances", typeof(MyPages.LeaveBalancePage), icon: "fa-balance-scale")]
[assembly: NavigationLink(2103, "Operations/Leave Management/Leave Calendar", typeof(MyPages.LeaveCalendarPage), icon: "fa-calendar")]
[assembly: NavigationLink(2104, "Operations/Leave Management/Leave Dashboard", typeof(MyPages.LeaveDashboardPage), icon: "fa-area-chart")]
[assembly: NavigationLink(2105, "Operations/Leave Management/Leave Reports", typeof(MyPages.LeaveReportsPage), icon: "fa-file-text")]
