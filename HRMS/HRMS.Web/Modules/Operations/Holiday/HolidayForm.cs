using Serenity.ComponentModel;

namespace HRMS.Operations.Forms;

[FormScript("Operations.Holiday")]
[BasedOnRow(typeof(HolidayRow), CheckNames = true)]
public class HolidayForm
{
    public string HolidayName { get; set; }
    public DateTime HolidayDate { get; set; }
    public HolidayType HolidayType { get; set; }
    public string Branch { get; set; }
    [TextAreaEditor(Rows = 2)]
    public string ApplicableDepartments { get; set; }
    public bool IsOptionalHoliday { get; set; }
    public int Year { get; set; }
}
