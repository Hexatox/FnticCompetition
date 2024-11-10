namespace DL.FnticCompetition.Models;

public class Class
{
    public int ClassID { get; set; }
    public DateTime ClassDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int BatchID { get; set; }
    public Batch Batch { get; set; }
    public int SectionID { get; set; }
    public Section Section { get; set; }
    public int GroupID { get; set; }
    public Group Group { get; set; }
}