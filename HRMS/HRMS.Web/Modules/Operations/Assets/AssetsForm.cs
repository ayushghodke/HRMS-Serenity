using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.Assets")]
[BasedOnRow(typeof(AssetsRow), CheckNames = true)]
public class AssetsForm
{
    public string AssetName { get; set; }
    public string SerialNumber { get; set; }
    public AssetType AssetType { get; set; }
    public AssetStatus Status { get; set; }
    public int AssignedTo { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Cost { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Description { get; set; }
}
