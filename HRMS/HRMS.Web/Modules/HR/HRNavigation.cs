using Serenity.Navigation;
using MyPages = HRMS.HR.Pages;

[assembly: NavigationMenu(1000, "HR", icon: "fa-sitemap")]
[assembly: NavigationLink(1000, "HR/Departments", typeof(MyPages.DepartmentPage), icon: "fa-building")]
[assembly: NavigationLink(1001, "HR/Designations", typeof(MyPages.DesignationPage), icon: "fa-id-badge")]
[assembly: NavigationLink(1002, "HR/Employees", typeof(MyPages.EmployeePage), icon: "fa-users")]
[assembly: NavigationLink(1003, "HR/Employee Salaries", typeof(MyPages.EmployeeSalaryPage), icon: "fa-money")]
