using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260219_120000)]
    public class DefaultDB_20260219_120000_SocialMediaManagement : AutoReversingMigration
    {
        public override void Up()
        {
            // Connected social media accounts
            Create.Table("SocialAccount")
                .WithColumn("SocialAccountId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Platform").AsInt32().NotNullable() // 1=Facebook, 2=Instagram, 3=LinkedIn
                .WithColumn("AccountName").AsString(200).NotNullable()
                .WithColumn("ProfileUrl").AsString(500).Nullable()
                .WithColumn("AccessToken").AsString(2000).Nullable()
                .WithColumn("RefreshToken").AsString(2000).Nullable()
                .WithColumn("TokenExpiry").AsDateTime().Nullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("ConnectedDate").AsDateTime().Nullable()
                .WithColumn("InsertUserId").AsInt32().NotNullable()
                .WithColumn("InsertDate").AsDateTime().NotNullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable();

            // Social media posts
            Create.Table("SocialPost")
                .WithColumn("SocialPostId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("SocialAccountId").AsInt32().NotNullable()
                    .ForeignKey("FK_SocialPost_SocialAccount", "SocialAccount", "SocialAccountId")
                .WithColumn("Title").AsString(300).Nullable()
                .WithColumn("Content").AsString(int.MaxValue).NotNullable()
                .WithColumn("PostType").AsInt32().NotNullable().WithDefaultValue(1) // 1=Text, 2=Image, 3=Video, 4=Carousel
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1)   // 1=Draft, 2=Scheduled, 3=Published, 4=Failed
                .WithColumn("ScheduledDate").AsDateTime().Nullable()
                .WithColumn("PublishedDate").AsDateTime().Nullable()
                .WithColumn("ExternalPostId").AsString(500).Nullable() // ID returned by the platform after publishing
                .WithColumn("ErrorMessage").AsString(2000).Nullable()
                .WithColumn("InsertUserId").AsInt32().NotNullable()
                .WithColumn("InsertDate").AsDateTime().NotNullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable();

            // Media attachments for posts
            Create.Table("SocialPostMedia")
                .WithColumn("SocialPostMediaId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("SocialPostId").AsInt32().NotNullable()
                    .ForeignKey("FK_SocialPostMedia_SocialPost", "SocialPost", "SocialPostId")
                .WithColumn("FileName").AsString(500).NotNullable()
                .WithColumn("MediaType").AsInt32().NotNullable().WithDefaultValue(1) // 1=Image, 2=Video
                .WithColumn("DisplayOrder").AsInt32().NotNullable().WithDefaultValue(0);
        }
    }
}
