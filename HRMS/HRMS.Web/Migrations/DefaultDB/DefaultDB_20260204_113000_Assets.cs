using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260204_113000)]
    public class DefaultDB_20260204_113000_Assets : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Assets")
                .WithColumn("AssetId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("AssetName").AsString(200).NotNullable()
                .WithColumn("SerialNumber").AsString(100).Nullable()
                .WithColumn("AssetType").AsInt32().NotNullable().WithDefaultValue(1) // 1=Laptop
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1) // 1=Available
                .WithColumn("AssignedTo").AsInt32().Nullable()
                    .ForeignKey("FK_Assets_AssignedTo", "Employees", "EmployeeId")
                .WithColumn("PurchaseDate").AsDateTime().Nullable()
                .WithColumn("Cost").AsCurrency().Nullable()
                .WithColumn("Description").AsString(int.MaxValue).Nullable();

            // Add Index for optimization (as per analysis report recommendation)
            Create.Index("IX_Assets_AssignedTo")
                .OnTable("Assets")
                .OnColumn("AssignedTo");
        }
    }
}
