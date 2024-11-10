namespace DL.FnticCompetition.Models;

public class Attendance
{
    public int AttendanceID { get; set; }
    public int ClassID { get; set; }
    public Class Class { get; set; }
    public int StudentID { get; set; }
    public Student Student { get; set; }
    public string Status { get; set; } // 'Present' or 'Absent'
    public DateTime Timestamp { get; set; }
}