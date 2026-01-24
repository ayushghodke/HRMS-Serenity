using Serenity.Navigation;
using MyPages = HRMS.Operations.Pages;

[assembly: NavigationMenu(2000, "Operations")]
[assembly: NavigationLink(2000, "Operations/Attendance", typeof(MyPages.AttendancePage), icon: "fa-clock-o")]
[assembly: NavigationLink(2001, "Operations/Leaves", typeof(MyPages.LeavePage), icon: "fa-calendar-minus-o")]
[assembly: NavigationLink(2002, "Operations/Payroll", typeof(MyPages.PayrollPage), icon: "fa-money")]
[assembly: NavigationLink(2003, "Operations/Tasks", typeof(MyPages.TaskPage), icon: "fa-tasks")]