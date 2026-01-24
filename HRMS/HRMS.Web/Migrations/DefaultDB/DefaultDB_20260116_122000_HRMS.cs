using FluentMigrator;

namespace HRMS.Migrations.DefaultDB
{
    [Migration(20260116_122000)]
    public class DefaultDB_20260116_122000_HRMS : AutoReversingMigration
    {
        public override void Up()
        {
            // Human Resources Module
            Create.Table("Departments")
                .WithColumn("DepartmentId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("DepartmentName").AsString(100).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(1);

            Create.Table("Designations")
                .WithColumn("DesignationId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("DesignationName").AsString(100).NotNullable()
                .WithColumn("Level").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(1);

            // Using "Employees" table, but user requested "UserId" link in Attendance.
            // Ideally Employee table links to User table.
            Create.Table("Employees")
                .WithColumn("EmployeeId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("UserId").AsInt32().Nullable()
                    .ForeignKey("FK_Employees_UserId", "Users", "UserId")
                .WithColumn("EmployeeCode").AsString(50).Nullable()
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("LastName").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Gender").AsInt32().Nullable()
                .WithColumn("DateOfBirth").AsDateTime().Nullable()
                .WithColumn("JoiningDate").AsDateTime().Nullable()
                .WithColumn("DepartmentId").AsInt32().Nullable()
                    .ForeignKey("FK_Employees_DepartmentId", "Departments", "DepartmentId")
                .WithColumn("DesignationId").AsInt32().Nullable()
                    .ForeignKey("FK_Employees_DesignationId", "Designations", "DesignationId")
                .WithColumn("ManagerId").AsInt32().Nullable()
                    .ForeignKey("FK_Employees_ManagerId", "Employees", "EmployeeId")
                .WithColumn("EmploymentType").AsInt32().NotNullable().WithDefaultValue(1) // 1=FullTime
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1) // Active
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime)
                .WithColumn("UpdatedDate").AsDateTime().Nullable();

            // Operations Module
            
            // Attendance (As per user request)
            Create.Table("Attendance")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("UserId").AsString(100).NotNullable() // "User Id" as String
                .WithColumn("Name").AsInt32().NotNullable() // Linked System User
                    .ForeignKey("FK_Attendance_Name", "Users", "UserId")
                .WithColumn("DateNTime").AsDateTime().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable()
                .WithColumn("Coordinates").AsString(200).NotNullable()
                .WithColumn("PunchOutCoordinates").AsString(200).Nullable()
                .WithColumn("Location").AsString(2000).NotNullable()
                .WithColumn("ApprovedBy").AsInt32().Nullable()
                    .ForeignKey("FK_Attendance_ApprovedBy", "Users", "UserId")
                .WithColumn("PunchIn").AsDateTime().NotNullable()
                .WithColumn("PunchOut").AsDateTime().Nullable() // Can be null if currently working
                .WithColumn("Distance").AsDouble().Nullable().WithDefaultValue(0);

            Create.Table("Leaves")
                .WithColumn("LeaveId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("EmployeeId").AsInt32().NotNullable()
                    .ForeignKey("FK_Leaves_EmployeeId", "Employees", "EmployeeId")
                .WithColumn("LeaveType").AsInt32().NotNullable()
                .WithColumn("StartDate").AsDateTime().NotNullable()
                .WithColumn("EndDate").AsDateTime().NotNullable()
                .WithColumn("TotalDays").AsDouble().NotNullable()
                .WithColumn("Reason").AsString(500).Nullable()
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0) // Pending
                .WithColumn("ApprovedBy").AsInt32().Nullable()
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime);

            Create.Table("Payroll")
                .WithColumn("PayrollId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("EmployeeId").AsInt32().NotNullable()
                    .ForeignKey("FK_Payroll_EmployeeId", "Employees", "EmployeeId")
                .WithColumn("Month").AsInt32().NotNullable()
                .WithColumn("Year").AsInt32().NotNullable()
                .WithColumn("BasicSalary").AsDecimal(18, 2).NotNullable()
                .WithColumn("Allowances").AsDecimal(18, 2).WithDefaultValue(0)
                .WithColumn("Deductions").AsDecimal(18, 2).WithDefaultValue(0)
                .WithColumn("NetSalary").AsDecimal(18, 2).NotNullable()
                .WithColumn("GeneratedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime);

            Create.Table("Tasks")
                .WithColumn("TaskId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString(200).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("AssignedTo").AsInt32().Nullable()
                    .ForeignKey("FK_Tasks_AssignedTo", "Employees", "EmployeeId")
                .WithColumn("AssignedBy").AsInt32().Nullable()
                .WithColumn("DueDate").AsDateTime().Nullable()
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0); // Pending
        }
    }
}
