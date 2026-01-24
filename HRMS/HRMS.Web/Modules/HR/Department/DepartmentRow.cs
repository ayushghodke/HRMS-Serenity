using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.HR;

[ConnectionKey("Default"), Module("HR"), TableName("Departments")]
[DisplayName("Departments"), InstanceName("Department")]
[ReadPermission("HR:Department")]
[ModifyPermission("HR:Department")]
[LookupScript]
public sealed class DepartmentRow : Row<DepartmentRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Department Id"), Identity, IdProperty]
    public int? DepartmentId
    {
        get => fields.DepartmentId[this];
        set => fields.DepartmentId[this] = value;
    }

    [DisplayName("Department Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string DepartmentName
    {
        get => fields.DepartmentName[this];
        set => fields.DepartmentName[this] = value;
    }

    [DisplayName("Description")]
    public string Description
    {
        get => fields.Description[this];
        set => fields.Description[this] = value;
    }

    [DisplayName("Is Active"), NotNull]
    public bool? IsActive
    {
        get => fields.IsActive[this];
        set => fields.IsActive[this] = value;
    }

    public class RowFields : RowFieldsBase
    {
        public Int32Field DepartmentId;
        public StringField DepartmentName;
        public StringField Description;
        public BooleanField IsActive;
    }
}
