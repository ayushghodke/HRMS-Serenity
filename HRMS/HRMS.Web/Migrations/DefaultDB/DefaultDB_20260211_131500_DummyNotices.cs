using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260211_131500)]
    public class DefaultDB_20260211_131500_DummyNotices : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Notice").Row(new
            {
                Title = "Annual Company Retreat",
                Description = "We are excited to announce our annual company retreat happening next month at the Grand Hotel. Please rsvp by Friday.",
                Priority = 2, // Normal
                PublishDate = DateTime.Now.AddDays(-2),
                ExpiryDate = DateTime.Now.AddDays(30),
                IsActive = true,
                InsertUserId = 1,
                InsertDate = DateTime.Now
            });

            Insert.IntoTable("Notice").Row(new
            {
                Title = "Urgent: IT Maintenance",
                Description = "Server maintenance scheduled for this Saturday from 10 PM to 2 AM. Services will be unavailable.",
                Priority = 3, // High
                PublishDate = DateTime.Now.AddDays(-1),
                ExpiryDate = DateTime.Now.AddDays(5),
                IsActive = true,
                InsertUserId = 1,
                InsertDate = DateTime.Now
            });

            Insert.IntoTable("Notice").Row(new
            {
                Title = "New HR Policy Update",
                Description = "Please review the updated remote work policy in the documents section. Effective immediately.",
                Priority = 2, // Normal
                PublishDate = DateTime.Now.AddDays(-5),
                ExpiryDate = DateTime.Now.AddDays(60),
                IsActive = true,
                InsertUserId = 1,
                InsertDate = DateTime.Now
            });

            Insert.IntoTable("Notice").Row(new
            {
                Title = "Welcome to the Team!",
                Description = "Let's welcome our new joiners for this month. We are happy to have you on board!",
                Priority = 1, // Low
                PublishDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(7),
                IsActive = true,
                InsertUserId = 1,
                InsertDate = DateTime.Now
            });
        }

        public override void Down()
        {
        }
    }
}
