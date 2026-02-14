using FluentMigrator;

namespace HRMS.Migrations.DefaultDB;

[Migration(20260214_170000)]
public class DefaultDB_20260214_170000_AdvancedLeaveManagement : Migration
{
    public override void Up()
    {
        Create.Table("LeaveTypes")
            .WithColumn("LeaveTypeId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("LeaveTypeName").AsString(100).NotNullable()
            .WithColumn("LeaveCode").AsString(20).NotNullable()
            .WithColumn("LeaveCategory").AsInt32().NotNullable()
            .WithColumn("AnnualAllocation").AsDecimal(7, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("MonthlyAccrual").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("CarryForwardAllowed").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("MaxCarryForwardDays").AsDecimal(7, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("EncashmentAllowed").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("ApplicableDepartments").AsString(2000).Nullable()
            .WithColumn("ApplicableDesignations").AsString(2000).Nullable()
            .WithColumn("ApplicableBranches").AsString(1000).Nullable()
            .WithColumn("GenderSpecific").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("ProbationApplicable").AsBoolean().NotNullable().WithDefaultValue(true)
            .WithColumn("MinimumServiceRequiredMonths").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("MaxLeavePerRequest").AsDecimal(7, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("SandwichRuleApplicable").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("HalfDayAllowed").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("DocumentsRequired").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1);

        Create.UniqueConstraint("UQ_LeaveTypes_LeaveCode")
            .OnTable("LeaveTypes").Column("LeaveCode");

        Create.Table("Holidays")
            .WithColumn("HolidayId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("HolidayName").AsString(150).NotNullable()
            .WithColumn("HolidayDate").AsDate().NotNullable()
            .WithColumn("HolidayType").AsInt32().NotNullable()
            .WithColumn("Branch").AsString(100).Nullable()
            .WithColumn("ApplicableDepartments").AsString(2000).Nullable()
            .WithColumn("IsOptionalHoliday").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("Year").AsInt32().NotNullable();

        Create.Table("LeavePolicies")
            .WithColumn("LeavePolicyId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("PolicyName").AsString(150).NotNullable()
            .WithColumn("ApplicableFromDate").AsDate().NotNullable()
            .WithColumn("Branch").AsString(100).Nullable()
            .WithColumn("DepartmentId").AsInt32().Nullable().ForeignKey("FK_LeavePolicies_DepartmentId", "Departments", "DepartmentId")
            .WithColumn("MaxConsecutiveLeavesAllowed").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("NoticePeriodLeaveAllowed").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("ProbationLeaveAllowed").AsBoolean().NotNullable().WithDefaultValue(true)
            .WithColumn("ApprovalLevels").AsInt32().NotNullable().WithDefaultValue(2)
            .WithColumn("HROverridePermission").AsBoolean().NotNullable().WithDefaultValue(true)
            .WithColumn("PayrollCutoffDay").AsInt32().NotNullable().WithDefaultValue(30)
            .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1);

        Create.Table("LeavePolicyLeaveTypes")
            .WithColumn("PolicyLeaveTypeId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("LeavePolicyId").AsInt32().NotNullable().ForeignKey("FK_LeavePolicyLeaveTypes_LeavePolicyId", "LeavePolicies", "LeavePolicyId")
            .WithColumn("LeaveTypeId").AsInt32().NotNullable().ForeignKey("FK_LeavePolicyLeaveTypes_LeaveTypeId", "LeaveTypes", "LeaveTypeId");

        Create.UniqueConstraint("UQ_LeavePolicyLeaveTypes_Policy_Type")
            .OnTable("LeavePolicyLeaveTypes").Columns("LeavePolicyId", "LeaveTypeId");

        Create.Table("EmployeeLeaveProfiles")
            .WithColumn("EmployeeLeaveProfileId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("EmployeeId").AsInt32().NotNullable().ForeignKey("FK_EmployeeLeaveProfiles_EmployeeId", "Employees", "EmployeeId")
            .WithColumn("LeavePolicyId").AsInt32().Nullable().ForeignKey("FK_EmployeeLeaveProfiles_LeavePolicyId", "LeavePolicies", "LeavePolicyId")
            .WithColumn("LeaveTypeId").AsInt32().NotNullable().ForeignKey("FK_EmployeeLeaveProfiles_LeaveTypeId", "LeaveTypes", "LeaveTypeId")
            .WithColumn("OpeningBalance").AsDecimal(9, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("AccruedLeave").AsDecimal(9, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("UsedLeave").AsDecimal(9, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("PendingLeave").AsDecimal(9, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("CarryForwardLeave").AsDecimal(9, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("LOPDays").AsDecimal(9, 2).NotNullable().WithDefaultValue(0)
            .WithColumn("LastUpdatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime);

        Create.UniqueConstraint("UQ_EmployeeLeaveProfiles_Employee_Type")
            .OnTable("EmployeeLeaveProfiles").Columns("EmployeeId", "LeaveTypeId");

        Create.Table("LeaveApprovals")
            .WithColumn("ApprovalId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("LeaveId").AsInt32().NotNullable().ForeignKey("FK_LeaveApprovals_LeaveId", "Leaves", "LeaveId")
            .WithColumn("ApproverId").AsInt32().NotNullable().ForeignKey("FK_LeaveApprovals_ApproverId", "Users", "UserId")
            .WithColumn("ApprovalLevel").AsInt32().NotNullable()
            .WithColumn("ApprovalDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime)
            .WithColumn("Status").AsInt32().NotNullable()
            .WithColumn("Remarks").AsString(2000).Nullable()
            .WithColumn("EscalationTrigger").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("EscalationTo").AsInt32().Nullable().ForeignKey("FK_LeaveApprovals_EscalationTo", "Users", "UserId")
            .WithColumn("TimeStamp").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime);

        Alter.Table("Leaves")
            .AddColumn("LeaveApplicationNo").AsString(30).Nullable()
            .AddColumn("ApplicationDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime)
            .AddColumn("LeaveTypeId").AsInt32().Nullable().ForeignKey("FK_Leaves_LeaveTypeId", "LeaveTypes", "LeaveTypeId")
            .AddColumn("HalfDaySession").AsInt32().Nullable()
            .AddColumn("Attachment").AsString(500).Nullable()
            .AddColumn("ReportingManagerId").AsInt32().Nullable().ForeignKey("FK_Leaves_ReportingManagerId", "Employees", "EmployeeId")
            .AddColumn("HrApprovalStatus").AsInt32().NotNullable().WithDefaultValue(0)
            .AddColumn("FinalStatus").AsInt32().NotNullable().WithDefaultValue(0)
            .AddColumn("ManagerRemarks").AsString(2000).Nullable()
            .AddColumn("HrRemarks").AsString(2000).Nullable()
            .AddColumn("SubstituteEmployeeId").AsInt32().Nullable().ForeignKey("FK_Leaves_SubstituteEmployeeId", "Employees", "EmployeeId")
            .AddColumn("ContactDuringLeave").AsString(200).Nullable()
            .AddColumn("CreatedByUserId").AsInt32().Nullable().ForeignKey("FK_Leaves_CreatedByUserId", "Users", "UserId");

        Create.Index("IX_Leaves_LeaveApplicationNo")
            .OnTable("Leaves").OnColumn("LeaveApplicationNo").Ascending();
    }

    public override void Down()
    {
        Delete.Index("IX_Leaves_LeaveApplicationNo").OnTable("Leaves");

        Delete.Column("LeaveApplicationNo").FromTable("Leaves");
        Delete.Column("ApplicationDate").FromTable("Leaves");
        Delete.Column("LeaveTypeId").FromTable("Leaves");
        Delete.Column("HalfDaySession").FromTable("Leaves");
        Delete.Column("Attachment").FromTable("Leaves");
        Delete.Column("ReportingManagerId").FromTable("Leaves");
        Delete.Column("HrApprovalStatus").FromTable("Leaves");
        Delete.Column("FinalStatus").FromTable("Leaves");
        Delete.Column("ManagerRemarks").FromTable("Leaves");
        Delete.Column("HrRemarks").FromTable("Leaves");
        Delete.Column("SubstituteEmployeeId").FromTable("Leaves");
        Delete.Column("ContactDuringLeave").FromTable("Leaves");
        Delete.Column("CreatedByUserId").FromTable("Leaves");

        Delete.Table("LeaveApprovals");
        Delete.Table("EmployeeLeaveProfiles");
        Delete.Table("LeavePolicyLeaveTypes");
        Delete.Table("LeavePolicies");
        Delete.Table("Holidays");
        Delete.Table("LeaveTypes");
    }
}
