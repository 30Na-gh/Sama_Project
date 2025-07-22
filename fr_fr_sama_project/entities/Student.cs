using System.Windows.Controls;

namespace fr_fr_sama_project.entities;

public class Student:Person
{
    public Student(string id, string name, string family, string stField, bool isActive) : base(id, name, family)
    {
        ID = id;
        Name = name;
        Family = family;
        StField = stField;
        IsActive = isActive;
    }
    public string StField { get; set; }
    public bool IsActive { get; set; }
    
}