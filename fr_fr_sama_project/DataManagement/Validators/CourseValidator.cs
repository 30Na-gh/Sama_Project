using fr_fr_sama_project.entities;

namespace fr_fr_sama_project.DataManagement.Validators;

public class CourseValidator
{
    public bool Validate(Course c)
    {
        if (string.IsNullOrWhiteSpace(c.CID) || c.CID == "" || string.IsNullOrEmpty(c.CID))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(c.CName) ||
            string.IsNullOrWhiteSpace(c.CType))
        {
            return false;
        }

        if (c.CUnit <= 0)
        {
            return false;
        }
        return true;
    }
}