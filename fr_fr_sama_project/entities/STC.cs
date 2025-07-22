namespace fr_fr_sama_project.entities;

public class STC
{
    public string StId { get; set; }
    public string TId { get; set; }
    public string CId { get; set; }
    public string Term { get; set; }
    public string Grade { get; set; }

    public STC(string stId, string tId, string cId, string term, string grade)
    {
        StId = stId;
        TId = tId;
        CId = cId;
        Term = term;
        Grade = grade;
    }
}