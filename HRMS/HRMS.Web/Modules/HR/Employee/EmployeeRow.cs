using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using HRMS.Administration;

namespace HRMS.HR;

[ConnectionKey("Default"), Module("HR"), TableName("Employees")]
[DisplayName("Employees"), InstanceName("Employee")]
[ReadPermission("HR:Employee")]
[ModifyPermission("HR:Employee")]
[LookupScript]
public sealed class EmployeeRow : Row<EmployeeRow.RowFields>, IIdRow, INameRow
{
    const string jUser = nameof(jUser);
    const string jDepartment = nameof(jDepartment);
    const string jDesignation = nameof(jDesignation);
    const string jManager = nameof(jManager);

    [DisplayName("Employee Id"), Identity, IdProperty]
    public int? EmployeeId { get => fields.EmployeeId[this]; set => fields.EmployeeId[this] = value; }

    [DisplayName("User"), ForeignKey(typeof(UserRow)), LeftJoin(jUser), TextualField(nameof(Username))]
    [LookupEditor(typeof(UserRow), Async = true)]
    public int? UserId { get => fields.UserId[this]; set => fields.UserId[this] = value; }

    [DisplayName("Employee Code"), Size(50), QuickSearch]
    public string EmployeeCode { get => fields.EmployeeCode[this]; set => fields.EmployeeCode[this] = value; }

    [DisplayName("First Name"), Size(100), NotNull, NameProperty]
    public string FirstName { get => fields.FirstName[this]; set => fields.FirstName[this] = value; }

    [DisplayName("Last Name"), Size(100), NotNull]
    public string LastName { get => fields.LastName[this]; set => fields.LastName[this] = value; }

    [DisplayName("Full Name"), Expression("(t0.FirstName + ' ' + t0.LastName)"), QuickSearch]
    public string FullName { get => fields.FullName[this]; set => fields.FullName[this] = value; }

    [DisplayName("Email"), Size(100)]
    public string Email { get => fields.Email[this]; set => fields.Email[this] = value; }

    [DisplayName("Phone"), Size(50)]
    public string Phone { get => fields.Phone[this]; set => fields.Phone[this] = value; }

    [DisplayName("Gender")]
    public Gender? Gender { get => (Gender?)fields.Gender[this]; set => fields.Gender[this] = (int?)value; }

    [DisplayName("Date Of Birth")]
    public DateTime? DateOfBirth { get => fields.DateOfBirth[this]; set => fields.DateOfBirth[this] = value; }

    [DisplayName("Joining Date")]
    public DateTime? JoiningDate { get => fields.JoiningDate[this]; set => fields.JoiningDate[this] = value; }

    [DisplayName("Department"), ForeignKey(typeof(DepartmentRow)), LeftJoin(jDepartment), TextualField(nameof(DepartmentName))]
    [LookupEditor(typeof(DepartmentRow), Async = true)]
    public int? DepartmentId { get => fields.DepartmentId[this]; set => fields.DepartmentId[this] = value; }

    [DisplayName("Designation"), ForeignKey(typeof(DesignationRow)), LeftJoin(jDesignation), TextualField(nameof(DesignationName))]
    [LookupEditor(typeof(DesignationRow), Async = true)]
    public int? DesignationId { get => fields.DesignationId[this]; set => fields.DesignationId[this] = value; }

    [DisplayName("Manager"), ForeignKey(typeof(EmployeeRow)), LeftJoin(jManager), TextualField(nameof(ManagerFullName))]
    [LookupEditor(typeof(EmployeeRow), Async = true)]
    public int? ManagerId { get => fields.ManagerId[this]; set => fields.ManagerId[this] = value; }

    [DisplayName("Employment Type"), NotNull, DefaultValue(1)]
    public EmploymentType? EmploymentType { get => (EmploymentType?)fields.EmploymentType[this]; set => fields.EmploymentType[this] = (int?)value; }

    [DisplayName("Status"), NotNull, DefaultValue(1)]
    public EmployeeStatus? Status { get => (EmployeeStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Username"), Origin(jUser, nameof(UserRow.Username))]
    public string Username { get => fields.Username[this]; set => fields.Username[this] = value; }

    [DisplayName("User Image"), Origin(jUser, nameof(UserRow.UserImage))]
    public string UserImage { get => fields.UserImage[this]; set => fields.UserImage[this] = value; }

    [DisplayName("Department"), Origin(jDepartment, nameof(DepartmentRow.DepartmentName))]
    public string DepartmentName { get => fields.DepartmentName[this]; set => fields.DepartmentName[this] = value; }

    [DisplayName("Designation"), Origin(jDesignation, nameof(DesignationRow.DesignationName))]
    public string DesignationName { get => fields.DesignationName[this]; set => fields.DesignationName[this] = value; }

    [DisplayName("Manager"), Origin(jManager, nameof(EmployeeRow.FullName))]
    public string ManagerFullName { get => fields.ManagerFullName[this]; set => fields.ManagerFullName[this] = value; }

    [DisplayName("Documents"), MasterDetailRelation(foreignKey: "EmployeeId", IncludeColumns = "Title,Description,DocumentType,FilePath,UploadedOn")]
    public List<EmployeeDocsRow> DocumentList { get => fields.DocumentList[this]; set => fields.DocumentList[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field EmployeeId;
        public Int32Field UserId;
        public StringField EmployeeCode;
        public StringField FirstName;
        public StringField LastName;
        public StringField FullName;
        public StringField Email;
        public StringField Phone;
        public Int32Field Gender;
        public DateTimeField DateOfBirth;
        public DateTimeField JoiningDate;
        public Int32Field DepartmentId;
        public Int32Field DesignationId;
        public Int32Field ManagerId;
        public Int32Field EmploymentType;
        public Int32Field Status;

        public StringField Username;
        public StringField UserImage;
        public StringField DepartmentName;
        public StringField DesignationName;
        public StringField ManagerFullName;

        public RowListField<EmployeeDocsRow> DocumentList;
    }
}

public enum Gender
{
    Male = 1,
    Female = 2,
    Other = 3
}

public enum EmploymentType
{
    FullTime = 1,
    PartTime = 2,
    Contract = 3,
    Intern = 4
}

public enum EmployeeStatus
{
    Active = 1,
    Inactive = 0,
    Terminated = -1
}
