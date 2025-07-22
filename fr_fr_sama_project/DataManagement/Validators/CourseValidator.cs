using System.Windows;
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

        if (c.CUnit <= 0 || c.CUnit > 4)
        {
            MessageBox.Show("تعداد واحد باید عددی بین 1 تا 3 باشد");
            return false;
        }
        return true;
    }
}