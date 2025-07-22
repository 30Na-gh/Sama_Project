using System.Windows;
using fr_fr_sama_project.entities;

namespace fr_fr_sama_project.DataManagement.Validators;

public class TeacherValidator
{
    public bool Validate(Teacher t)
    {
        
        if (string.IsNullOrWhiteSpace(t.ID))
        {
            MessageBox.Show("شماره استاد نمی‌تواند خالی باشد.");
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(t.ID) ||
            string.IsNullOrWhiteSpace(t.Name) ||
            string.IsNullOrWhiteSpace(t.Family) ||
            string.IsNullOrWhiteSpace(t.TDegree))
        {
            MessageBox.Show("لطفا همه فیلد هارا پر کنید");
            return false;
        }
        
        if (t.TSalary <= 0)
        {
            MessageBox.Show("حقوق استاد باید عدد مثبت باشد.");
            return false;
        }
        
        return true;
    }
}