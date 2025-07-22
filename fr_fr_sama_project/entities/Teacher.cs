using System.Windows.Controls;

namespace fr_fr_sama_project.entities;

public class Teacher: Person
{
    
    public Teacher(string id, string name, string family, string degree, int salary, bool isActive) : base(id, name, family)
    {
        
        ID = id;
        Name = name;
        Family = family;
        TDegree = degree;
        TSalary = salary;
        IsActive = isActive;
    }
    public string TDegree { get; set; }
    public int TSalary { get; set; }
    public bool IsActive { get; set; }
}