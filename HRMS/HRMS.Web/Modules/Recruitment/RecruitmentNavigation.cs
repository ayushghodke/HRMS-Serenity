using Serenity.Navigation;
using MyPages = HRMS.Recruitment.Pages;

[assembly: NavigationMenu(6000, "Recruitment", icon: "fa-users")]
[assembly: NavigationLink(6100, "Recruitment/Job Openings", typeof(MyPages.JobOpeningsPage), icon: "fa-briefcase")]
[assembly: NavigationLink(6200, "Recruitment/Candidates", typeof(MyPages.CandidatesPage), icon: "fa-user-plus")]
[assembly: NavigationLink(6250, "Recruitment/Candidate Kanban", typeof(MyPages.CandidateKanbanPage), icon: "fa-columns")]
[assembly: NavigationLink(6300, "Recruitment/Interviews", typeof(MyPages.InterviewsPage), icon: "fa-comments")]
[assembly: NavigationLink(6350, "Recruitment/Interview Calendar", typeof(MyPages.InterviewCalendarPage), icon: "fa-calendar")]