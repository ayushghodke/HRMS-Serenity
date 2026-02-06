
namespace HRMS.MVC;

public static partial class Views
{
    public static partial class Common
    {
        public static partial class Dashboard
        {
            public const string DashboardIndex = "~/Modules/Common/Dashboard/DashboardIndex.cshtml";
        }
    }

    public static partial class Errors
    {
        public const string AccessDenied = "~/Views/Errors/AccessDenied.cshtml";
        public const string ValidationError = "~/Views/Errors/ValidationError.cshtml";
    }

    public static partial class Membership
    {
        public static partial class Account
        {
            public static partial class Login
            {
                public const string LoginPage = "~/Modules/Membership/Account/Login/LoginPage.cshtml";
            }

            public static partial class SignUp
            {
                public const string ActivateEmail = "~/Modules/Membership/Account/SignUp/ActivateEmail.cshtml";
                public const string SignUpPage = "~/Modules/Membership/Account/SignUp/SignUpPage.cshtml";
            }
        }
    }

    public static partial class Operations
    {
        public static partial class Assets
        {
            public const string AssetKanbanIndex = "~/Modules/Operations/Assets/AssetKanbanIndex.cshtml";
        }

        public static partial class LeaveCalendar
        {
            public const string LeaveCalendarIndex = "~/Modules/Operations/LeaveCalendar/LeaveCalendarIndex.cshtml";
        }

        public static partial class Task
        {
            public const string TaskKanbanIndex = "~/Modules/Operations/Task/TaskKanbanIndex.cshtml";
        }
    }

    public static partial class Recruitment
    {
        public static partial class CandidateKanban
        {
            public const string CandidateKanbanIndex = "~/Modules/Recruitment/CandidateKanban/CandidateKanbanIndex.cshtml";
        }

        public static partial class InterviewCalendar
        {
            public const string InterviewCalendarIndex = "~/Modules/Recruitment/InterviewCalendar/InterviewCalendarIndex.cshtml";
        }
    }

    public static partial class Shared
    {
        public const string _Layout = "~/Views/Shared/_Layout.cshtml";
        public const string _LayoutHead = "~/Views/Shared/_LayoutHead.cshtml";
        public const string _LayoutNoNavigation = "~/Views/Shared/_LayoutNoNavigation.cshtml";
        public const string _Sidebar = "~/Views/Shared/_Sidebar.cshtml";
        public const string Error = "~/Views/Shared/Error.cshtml";
    }
}