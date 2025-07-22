using System.Windows;
using fr_fr_sama_project.entities;

namespace fr_fr_sama_project.DataManagement.Validators;

public class StValidator
{
    public bool Validate(Student s)
    {
       
            if (string.IsNullOrWhiteSpace(s.ID))
            {
                MessageBox.Show("شماره دانشجو نمی‌تواند خالی باشد.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(s.Name) ||
                string.IsNullOrWhiteSpace(s.Family) ||
                string.IsNullOrWhiteSpace(s.StField))
            {
                MessageBox.Show("لطفا همه فیلد هارا پر کنید");
                return false;
            }
            
            return true;
        }
    
}