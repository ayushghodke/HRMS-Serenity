using Serenity.ComponentModel;
using System.ComponentModel;

namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.Holiday")]
[BasedOnRow(typeof(HolidayRow), CheckNames = true)]
public class HolidayColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int HolidayId { get; set; }
    [EditLink]
    public string HolidayName { get; set; }
    public DateTime HolidayDate { get; set; }
    public HolidayType HolidayType { get; set; }
    public string Branch { get; set; }
    public bool IsOptionalHoliday { get; set; }
    public int Year { get; set; }
}
