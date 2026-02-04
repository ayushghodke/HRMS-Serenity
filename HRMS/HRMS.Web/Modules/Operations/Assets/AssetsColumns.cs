using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.Assets")]
[BasedOnRow(typeof(AssetsRow), CheckNames = true)]
public class AssetsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int AssetId { get; set; }
    [EditLink]
    public string AssetName { get; set; }
    public string SerialNumber { get; set; }
    public AssetType AssetType { get; set; }
    public AssetStatus Status { get; set; }
    public string AssignedToFullName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Cost { get; set; }
}
