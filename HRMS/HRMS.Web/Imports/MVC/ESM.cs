namespace HRMS.MVC;

public static partial class ESM
{
    public const string AttendancePage = "~/esm/Modules/Operations/Attendance/AttendancePage.js";
    public const string CandidatesPage = "~/esm/Modules/Recruitment/Candidates/CandidatesPage.js";
    public const string DepartmentPage = "~/esm/Modules/HR/Department/DepartmentPage.js";
    public const string DesignationPage = "~/esm/Modules/HR/Designation/DesignationPage.js";
    public const string EmployeePage = "~/esm/Modules/HR/Employee/EmployeePage.js";
    public const string InterviewsPage = "~/esm/Modules/Recruitment/Interviews/InterviewsPage.js";
    public const string JobOpeningsPage = "~/esm/Modules/Recruitment/JobOpenings/JobOpeningsPage.js";
    public const string LanguagePage = "~/esm/Modules/Administration/Language/LanguagePage.js";
    public const string LeavePage = "~/esm/Modules/Operations/Leave/LeavePage.js";
    public const string LoginPage = "~/esm/Modules/Membership/Account/Login/LoginPage.js";
    public const string PayrollPage = "~/esm/Modules/Operations/Payroll/PayrollPage.js";
    public const string RolePage = "~/esm/Modules/Administration/Role/RolePage.js";
    public const string ScriptInit = "~/esm/Modules/Common/ScriptInit.js";
    public const string SignUpPage = "~/esm/Modules/Membership/Account/SignUp/SignUpPage.js";
    public const string TaskPage = "~/esm/Modules/Operations/Task/TaskPage.js";
    public const string TranslationPage = "~/esm/Modules/Administration/Translation/TranslationPage.js";
    public const string UserPage = "~/esm/Modules/Administration/User/UserPage.js";

    public static partial class Modules
    {
        public static partial class Administration
        {
            public static partial class Language
            {
                public const string LanguagePage = "~/esm/Modules/Administration/Language/LanguagePage.js";
            }

            public static partial class Role
            {
                public const string RolePage = "~/esm/Modules/Administration/Role/RolePage.js";
            }

            public static partial class Translation
            {
                public const string TranslationPage = "~/esm/Modules/Administration/Translation/TranslationPage.js";
            }

            public static partial class User
            {
                public const string UserPage = "~/esm/Modules/Administration/User/UserPage.js";
            }
        }

        public static partial class Common
        {
            public const string ScriptInit = "~/esm/Modules/Common/ScriptInit.js";
        }

        public static partial class HR
        {
            public static partial class Department
            {
                public const string DepartmentPage = "~/esm/Modules/HR/Department/DepartmentPage.js";
            }

            public static partial class Designation
            {
                public const string DesignationPage = "~/esm/Modules/HR/Designation/DesignationPage.js";
            }

            public static partial class Employee
            {
                public const string EmployeePage = "~/esm/Modules/HR/Employee/EmployeePage.js";
            }
        }

        public static partial class Membership
        {
            public static partial class Account
            {
                public static partial class Login
                {
                    public const string LoginPage = "~/esm/Modules/Membership/Account/Login/LoginPage.js";
                }

                public static partial class SignUp
                {
                    public const string SignUpPage = "~/esm/Modules/Membership/Account/SignUp/SignUpPage.js";
                }
            }
        }

        public static partial class Operations
        {
            public static partial class Attendance
            {
                public const string AttendancePage = "~/esm/Modules/Operations/Attendance/AttendancePage.js";
            }

            public static partial class Leave
            {
                public const string LeavePage = "~/esm/Modules/Operations/Leave/LeavePage.js";
            }

            public static partial class Payroll
            {
                public const string PayrollPage = "~/esm/Modules/Operations/Payroll/PayrollPage.js";
            }

            public static partial class Task
            {
                public const string TaskPage = "~/esm/Modules/Operations/Task/TaskPage.js";
            }
        }

        public static partial class Recruitment
        {
            public static partial class Candidates
            {
                public const string CandidatesPage = "~/esm/Modules/Recruitment/Candidates/CandidatesPage.js";
            }

            public static partial class Interviews
            {
                public const string InterviewsPage = "~/esm/Modules/Recruitment/Interviews/InterviewsPage.js";
            }

            public static partial class JobOpenings
            {
                public const string JobOpeningsPage = "~/esm/Modules/Recruitment/JobOpenings/JobOpeningsPage.js";
            }
        }
    }
}