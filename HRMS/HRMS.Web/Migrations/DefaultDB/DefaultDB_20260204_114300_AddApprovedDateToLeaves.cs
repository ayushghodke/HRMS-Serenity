using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260204_114300)]
    public class DefaultDB_20260204_114300_AddApprovedDateToLeaves : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Leaves")
                .AddColumn("ApprovedDate").AsDateTime().Nullable();
        }
    }
}
