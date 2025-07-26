using System.Windows;
using fr_fr_sama_project.entities;

namespace fr_fr_sama_project.DataManagement.Validators;

public class GradeValidator
{
    public bool Validate(STC stc)
    {
        if (stc.Term > 12 || stc.Term <= 0)
        {
            MessageBox.Show("شماره ترم باید بین 1 تا 12 باشد");
            return false;
        }
        if (stc.Grade > 20 || stc.Grade < 0)
        { 
            MessageBox.Show("نمره باید عددی بین 0 تا 20 باشد");
            return false;
        }
        
        return true;
    }
}