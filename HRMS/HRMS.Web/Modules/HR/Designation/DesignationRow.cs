using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.HR;

[ConnectionKey("Default"), Module("HR"), TableName("Designations")]
[DisplayName("Designations"), InstanceName("Designation")]
[ReadPermission("HR:Designation")]
[ModifyPermission("HR:Designation")]
[LookupScript]
public sealed class DesignationRow : Row<DesignationRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Designation Id"), Identity, IdProperty]
    public int? DesignationId
    {
        get => fields.DesignationId[this];
        set => fields.DesignationId[this] = value;
    }

    [DisplayName("Designation Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string DesignationName
    {
        get => fields.DesignationName[this];
        set => fields.DesignationName[this] = value;
    }

    [DisplayName("Level"), NotNull]
    public int? Level
    {
        get => fields.Level[this];
        set => fields.Level[this] = value;
    }

    [DisplayName("Is Active"), NotNull]
    public bool? IsActive
    {
        get => fields.IsActive[this];
        set => fields.IsActive[this] = value;
    }

    public class RowFields : RowFieldsBase
    {
        public Int32Field DesignationId;
        public StringField DesignationName;
        public Int32Field Level;
        public BooleanField IsActive;
    }
}
