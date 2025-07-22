using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using fr_fr_sama_project.DataManagement;
using fr_fr_sama_project.DataManagement.Validators;
using fr_fr_sama_project.entities;
namespace fr_fr_sama_project.MVVM.View;

public partial class TeacherView : UserControl
{
    public TeacherView()
    {
        InitializeComponent();
        TeacherSalaryTb.Text = "0";
    }

    private void TeacherDg_OnLoaded(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select * from Teacher where IsActive = 1";
        TeacherDg.ItemsSource = md.ShowData().DefaultView;
        TeacherDg.Columns[5].Visibility = Visibility.Collapsed;
    }

    private void AddTeacherBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Teacher t1 = new Teacher(Convert.ToString(TeacherIdTb.Text),
            Convert.ToString(TeacherNameTb.Text),
            Convert.ToString(TeacherFamilyTb.Text),
            Convert.ToString(TeacherDegree.Text),
            Convert.ToInt32(TeacherSalaryTb.Text),
            true);
        TeacherValidator TVA = new TeacherValidator();
        if (TVA.Validate(t1) == false)
        {
            return;
        }

        MyData md = new MyData();
        md.Command = $"insert into Teacher (TID, TName, TFamily, TDegree, TSalary, IsActive) values " +
                     $"('{t1.ID}','{t1.Name}','{t1.Family}','{t1.TDegree}','{t1.TSalary}','{t1.IsActive}')";
        md.ManData();
        MessageBox.Show("افزودن استاد با موفقیت انجام شد");
    }

    private void ShowTeacherBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select * from Teacher where IsActive = 1";
        TeacherDg.ItemsSource = md.ShowData().DefaultView;
        TeacherDg.Columns[5].Visibility = Visibility.Collapsed;
        MessageBox.Show("لیست اساتید با موفقیت به روز رسانی شد");
    }

    private void EditTeacherBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        DataRowView selectedDataRowView = TeacherDg.SelectedItem as DataRowView;
        
        if (selectedDataRowView != null)
        {
            string TempTID = selectedDataRowView.Row["TID"].ToString(); 
            if (TeacherIdTb.Text == "")
            {
                MessageBox.Show("لطفاً یک سطر را برای ویرایش انتخاب کنید");
                return;
            }

            md.Command = $"UPDATE Teacher SET TID=N'{TeacherIdTb.Text}', TName=N'{TeacherNameTb.Text}', " + 
                         $"TFamily=N'{TeacherFamilyTb.Text}', TDegree=N'{TeacherDegree.Text}',TSalary =N'{TeacherSalaryTb.Text}'" + 
                         $"WHERE TID=N'{TempTID}'";
            md.ManData();
            MessageBox.Show("استاد با موفقیت ویرایش شد");
        }
        else
        {
            MessageBox.Show("لطفاً یک سطر را برای ویرایش انتخاب کنید.");
        }
    }

    private void TeacherSalaryTb_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TeacherSalaryTb.Text))
        {
            TeacherSalaryTb.Text = "0";
        }
    }

    private void TeacherDg_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is DataRowView selectedDataRowView)
        {
            TeacherIdTb.Text = selectedDataRowView.Row["TID"].ToString();
            TeacherNameTb.Text = selectedDataRowView.Row["TName"].ToString();
            TeacherFamilyTb.Text = selectedDataRowView.Row["TFamily"].ToString();
            TeacherDegree.Text = selectedDataRowView.Row["TDegree"].ToString();
            TeacherSalaryTb.Text = selectedDataRowView.Row["TSalary"].ToString();
        }
    }

    private void CleanBtn_OnClick(object sender, RoutedEventArgs e)
    {
        TeacherIdTb.Text = "";
        TeacherNameTb.Text = "";
        TeacherFamilyTb.Text = "";
        TeacherDegree.Text = "";
        TeacherSalaryTb.Text = "0";
    }

    private void DeleteTeacherBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"update Teacher set IsActive = 0 where TID =N'{TeacherIdTb.Text}'";
        if (TeacherIdTb.Text == "")
        {
            MessageBox.Show("لطفا یک سطر را برای حذف انتخاب کنید");
        }
        else
        {
            md.ManData();
            MessageBox.Show("با موفقیت حذف شد");
        }  
    }

    private void SearchTeacherBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"select * from Teacher where TID = '{TeacherIdTb.Text}' and IsActive = 'true'";
        DataTable dt = md.ShowData();
        TeacherDg.ItemsSource = dt.DefaultView;
        TeacherDg.Columns[5].Visibility = Visibility.Collapsed;

        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            TeacherIdTb.Text = row["TID"].ToString();
            TeacherNameTb.Text = row["TName"].ToString();
            TeacherFamilyTb.Text = row["TFamily"].ToString();
            TeacherDegree.Text = row["TDegree"].ToString();
            TeacherSalaryTb.Text = row["TSalary"].ToString();
        }
        else
        {
            MessageBox.Show("There is no student with that ID");
        }
    }

    private void ModernSearch_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"select * from Teacher where TID like '{ModernSearch.Text}%' and IsActive = 1" ;
        TeacherDg.ItemsSource = md.ShowData().DefaultView;
        TeacherDg.Columns[5].Visibility = Visibility.Collapsed;
    }
}