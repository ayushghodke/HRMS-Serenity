using Serenity.Navigation;
using MyPages = HRMS.Communication.Pages;

[assembly: NavigationMenu(3000, "Communication", icon: "fa-bullhorn")]
[assembly: NavigationLink(3005, "Communication/Notice Board", typeof(MyPages.NoticePage), icon: "fa-envelope-o")]
[assembly: NavigationLink(3010, "Communication/Social Accounts", typeof(MyPages.SocialAccountPage), icon: "fa-plug")]
[assembly: NavigationLink(3015, "Communication/Social Posts", typeof(MyPages.SocialPostPage), icon: "fa-share-alt")]
[assembly: NavigationLink(3020, "Communication/Content Calendar", typeof(MyPages.SocialCalendarPage), icon: "fa-calendar")]
[assembly: NavigationLink(3025, "Communication/Platform Settings", typeof(MyPages.SocialPlatformConfigPage), icon: "fa-cog")]
