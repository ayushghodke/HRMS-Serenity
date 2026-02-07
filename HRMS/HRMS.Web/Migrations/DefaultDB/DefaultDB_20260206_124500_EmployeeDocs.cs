using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260206_124500)]
    public class DefaultDB_20260206_124500_EmployeeDocs : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("EmployeeDocs")
                .WithColumn("DocumentId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("EmployeeId").AsInt32().NotNullable().ForeignKey("FK_EmployeeDocs_EmployeeId", "Employee", "EmployeeId")
                .WithColumn("DocumentType").AsInt32().NotNullable() // 1=Aadhar, 2=PAN, 3=Other
                .WithColumn("Title").AsString(200).Nullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("FilePath").AsString(1000).Nullable()
                .WithColumn("UploadedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
    }
}
