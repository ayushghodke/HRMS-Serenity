using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;
using HRMS.HR;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("Assets")]
[DisplayName("Assets"), InstanceName("Asset")]
[ReadPermission("Operations:Assets")]
[ModifyPermission("Operations:Assets")]
[LookupScript]
public sealed class AssetsRow : Row<AssetsRow.RowFields>, IIdRow, INameRow
{
    const string jAssignedTo = nameof(jAssignedTo);

    [DisplayName("Asset Id"), Identity, IdProperty]
    public int? AssetId { get => fields.AssetId[this]; set => fields.AssetId[this] = value; }

    [DisplayName("Asset Name"), Size(200), NotNull, QuickSearch, NameProperty]
    public string AssetName { get => fields.AssetName[this]; set => fields.AssetName[this] = value; }

    [DisplayName("Serial Number"), Size(100)]
    public string SerialNumber { get => fields.SerialNumber[this]; set => fields.SerialNumber[this] = value; }

    [DisplayName("Type"), NotNull, DefaultValue(Operations.AssetType.Laptop)]
    public AssetType? AssetType { get => (AssetType?)fields.AssetType[this]; set => fields.AssetType[this] = (int?)value; }

    [DisplayName("Status"), NotNull, DefaultValue(Operations.AssetStatus.Available)]
    public AssetStatus? Status { get => (AssetStatus?)fields.Status[this]; set => fields.Status[this] = (int?)value; }

    [DisplayName("Assigned To"), ForeignKey(typeof(EmployeeRow)), LeftJoin(jAssignedTo), TextualField(nameof(AssignedToFullName))]
    [LookupEditor(typeof(EmployeeRow))]
    public int? AssignedTo { get => fields.AssignedTo[this]; set => fields.AssignedTo[this] = value; }

    [DisplayName("Purchase Date")]
    public DateTime? PurchaseDate { get => fields.PurchaseDate[this]; set => fields.PurchaseDate[this] = value; }

    [DisplayName("Cost"), Size(19), Scale(4)]
    public decimal? Cost { get => fields.Cost[this]; set => fields.Cost[this] = value; }

    [DisplayName("Description"), Size(int.MaxValue)]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Assigned To"), Expression($"{jAssignedTo}.[FirstName] + ' ' + {jAssignedTo}.[LastName]")]
    public string AssignedToFullName { get => fields.AssignedToFullName[this]; set => fields.AssignedToFullName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field AssetId;
        public StringField AssetName;
        public StringField SerialNumber;
        public Int32Field AssetType;
        public Int32Field Status;
        public Int32Field AssignedTo;
        public DateTimeField PurchaseDate;
        public DecimalField Cost;
        public StringField Description;

        public StringField AssignedToFullName;
    }
}

public enum AssetType
{
    [Description("Laptop")]
    Laptop = 1,
    [Description("Desktop")]
    Desktop = 2,
    [Description("Mobile Phone")]
    Mobile = 3,
    [Description("Tablet")]
    Tablet = 4,
    [Description("Monitor")]
    Monitor = 5,
    [Description("Furniture")]
    Furniture = 6,
    [Description("Vehicle")]
    Vehicle = 7,
    [Description("Other")]
    Other = 99
}

public enum AssetStatus
{
    [Description("Available")]
    Available = 1,
    [Description("In Use")]
    In_Use = 2,
    [Description("In Repair")]
    In_Repair = 3,
    [Description("Retired")]
    Retired = 4,
    [Description("Lost/Stolen")]
    Lost_Stolen = 5
}
