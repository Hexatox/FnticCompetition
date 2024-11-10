namespace DL.FnticCompetition.Models;

public class Group
{
    public int GroupID { get; set; }
    public string GroupName { get; set; }
    public int BatchID { get; set; }
    public Batch Batch { get; set; }
}