using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260211_131000)]
    public class DefaultDB_20260211_131000_NoticeBoard : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Notice")
                .WithColumn("NoticeId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString(200).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).NotNullable()
                .WithColumn("Priority").AsInt32().NotNullable().WithDefaultValue(1) // 1: Low, 2: Normal, 3: High
                .WithColumn("PublishDate").AsDateTime().NotNullable()
                .WithColumn("ExpiryDate").AsDateTime().Nullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(1)
                
                .WithColumn("InsertUserId").AsInt32().NotNullable()
                .WithColumn("InsertDate").AsDateTime().NotNullable()
                .WithColumn("UpdateUserId").AsInt32().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable();
        }
    }
}
