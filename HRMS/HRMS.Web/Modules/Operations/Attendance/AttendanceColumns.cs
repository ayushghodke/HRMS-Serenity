namespace HRMS.Operations.Columns;

[ColumnsScript("Operations.Attendance")]
[BasedOnRow(typeof(AttendanceRow), CheckNames = true)]
public class AttendanceColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string UserId { get; set; }
    public string NameUsername { get; set; }
    public DateTime DateNTime { get; set; }
    public int Type { get; set; }
    public string Coordinates { get; set; }
    public string PunchOutCoordinates { get; set; }
    public string Location { get; set; }
    public string ApprovedByUsername { get; set; }
    public DateTime PunchIn { get; set; }
    public DateTime PunchOut { get; set; }
    public double Distance { get; set; }
}