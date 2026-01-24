namespace HRMS.Operations.Forms;

[FormScript("Operations.Attendance")]
[BasedOnRow(typeof(AttendanceRow), CheckNames = true)]
public class AttendanceForm
{
    public string UserId { get; set; }
    public int Name { get; set; }
    public DateTime DateNTime { get; set; }
    public int Type { get; set; }
    public string Coordinates { get; set; }
    public string PunchOutCoordinates { get; set; }
    public string Location { get; set; }
    public int ApprovedBy { get; set; }
    public DateTime PunchIn { get; set; }
    public DateTime PunchOut { get; set; }
    public double Distance { get; set; }
}