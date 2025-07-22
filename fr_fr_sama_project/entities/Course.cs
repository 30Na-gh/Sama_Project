namespace fr_fr_sama_project.entities;

public class Course
{
    public string CID { get; set; }
    public string CName { get; set; }
    public string CType { get; set; }
    public int CUnit { get; set; }
    public bool IsActive { get; set; }
    public string DisplayInfo => $"{CID} - {CType} {CName}";

    public Course(string cid, string cname, string ctype, int cunit, bool isActive)
    {
        CID = cid;
        CName = cname;
        CType = ctype;
        CUnit = cunit;
        IsActive = isActive;
    }

    public Course()
    { }
}