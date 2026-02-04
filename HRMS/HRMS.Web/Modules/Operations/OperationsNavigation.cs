using Serenity.Navigation;
using MyPages = HRMS.Operations.Pages;

[assembly: NavigationMenu(2000, "Operations", icon: "fa-cogs")]
[assembly: NavigationLink(2000, "Operations/Attendance", typeof(MyPages.AttendancePage), icon: "fa-clock-o")]
[assembly: NavigationLink(2002, "Operations/Payroll", typeof(MyPages.PayrollPage), icon: "fa-money")]
[assembly: NavigationLink(2003, "Operations/Tasks", typeof(MyPages.TaskPage), icon: "fa-tasks")]

// Leave Management Submenu
[assembly: NavigationMenu(2100, "Operations/Leave Management", icon: "fa-calendar-check-o")]
[assembly: NavigationLink(2101, "Operations/Leave Management/Leave Requests", typeof(MyPages.LeavePage), icon: "fa-calendar-minus-o")]
[assembly: NavigationLink(2102, "Operations/Leave Management/Leave Balances", typeof(MyPages.LeaveBalancePage), icon: "fa-balance-scale")]
[assembly: NavigationLink(2103, "Operations/Leave Management/Leave Calendar", typeof(MyPages.LeaveCalendarPage), icon: "fa-calendar")]