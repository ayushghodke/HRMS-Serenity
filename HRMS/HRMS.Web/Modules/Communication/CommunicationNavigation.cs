using Serenity.Navigation;
using MyPages = HRMS.Communication.Pages;

[assembly: NavigationMenu(3000, "Communication", icon: "fa-bullhorn")]
[assembly: NavigationLink(3005, "Communication/Notice Board", typeof(MyPages.NoticePage), icon: "fa-envelope-o")]
