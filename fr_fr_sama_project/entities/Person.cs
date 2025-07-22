using System.Windows.Controls;

namespace fr_fr_sama_project.entities;

public class Person
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public Person(string id, string name, string family)
    {
        ID = id;
        Name = name;
        Family = family;
    }
}