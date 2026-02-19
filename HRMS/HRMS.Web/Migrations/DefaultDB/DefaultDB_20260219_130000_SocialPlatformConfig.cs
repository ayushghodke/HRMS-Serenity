using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260219_130000)]
    public class DefaultDB_20260219_130000_SocialPlatformConfig : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("SocialPlatformConfig")
                .WithColumn("SocialPlatformConfigId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Platform").AsInt32().NotNullable().Unique()
                .WithColumn("ClientId").AsString(500).Nullable()
                .WithColumn("ClientSecret").AsString(500).Nullable()
                .WithColumn("RedirectUri").AsString(500).Nullable()
                .WithColumn("IsEnabled").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("InsertUserId").AsInt32().NotNullable()
                .WithColumn("InsertDate").AsDateTime().NotNullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable();
        }
    }
}
