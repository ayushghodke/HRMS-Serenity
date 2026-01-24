using Serenity.ComponentModel;

namespace HRMS.HR.Forms;

[FormScript("HR.Designation")]
[BasedOnRow(typeof(DesignationRow), CheckNames = true)]
public class DesignationForm
{
    public string DesignationName { get; set; }
    public int Level { get; set; }
    public bool IsActive { get; set; }
}
