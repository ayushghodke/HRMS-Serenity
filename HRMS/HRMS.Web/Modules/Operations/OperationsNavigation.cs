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
[assembly: NavigationLink(2101, "Operations/Leave Management/Leave Requests", typeof(MyPages.LeavePage), icon: "fa-calendar-minus-o")]
[assembly: NavigationLink(2102, "Operations/Leave Management/Leave Balances", typeof(MyPages.LeaveBalancePage), icon: "fa-balance-scale")]
[assembly: NavigationLink(2103, "Operations/Leave Management/Leave Calendar", typeof(MyPages.LeaveCalendarPage), icon: "fa-calendar")]