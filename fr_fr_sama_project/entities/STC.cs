namespace fr_fr_sama_project.entities;

public class STC
{
    public string StId { get; set; }
    public string TId { get; set; }
    public string CId { get; set; }
    public int Term { get; set; }
    public int Grade { get; set; }

    public STC(string stId, string tId, string cId, int term, int grade)
    {
        StId = stId;
        TId = tId;
        CId = cId;
        Term = term;
        Grade = grade;
    }
}