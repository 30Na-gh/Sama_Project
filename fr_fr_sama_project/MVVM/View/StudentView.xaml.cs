using System.Windows.Controls;
using System.Windows;
using fr_fr_sama_project.DataManagement;
using fr_fr_sama_project.DataManagement.Validators;
using fr_fr_sama_project.entities;
using fr_fr_sama_project;
using System.Data;

namespace fr_fr_sama_project.MVVM.View;

public partial class StudentView : UserControl
{
    private Student _selectedStudent;
    private bool IsStActive;
    public StudentView()
    {
        InitializeComponent();
    }
    
    private void StudentDg_OnLoaded(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select * from Student where IsActive = 1";
        StudentDg.ItemsSource = md.ShowData().DefaultView;
        StudentDg.Columns[4].Visibility = Visibility.Collapsed;
    }

    private void StudentShowBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select * from Student where IsActive = 1";
        StudentDg.ItemsSource = md.ShowData().DefaultView;
        StudentDg.Columns[4].Visibility = Visibility.Collapsed;
        MessageBox.Show("لیست دانشجویان با موفقیت به روز شد");
    }

    private void AddStudentBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Student s1 = new Student(Convert.ToString(StudentIdTb.Text), 
                              Convert.ToString(StudentNameTb.Text),
                              Convert.ToString(StudentFamilyTb.Text), 
                              Convert.ToString(StudentField.Text), 
                              true);
        StValidator StVa = new StValidator();
        if (StVa.Validate(s1) == false)
        {
            return;
        }
        MyData md = new MyData();
        md.Command = $"insert into Student (StID,StName,StFamily,StField,IsActive) values " +
                     $"('{s1.ID}','{s1.Name}','{s1.Family}','{s1.StField}','{s1.IsActive}')";
        md.ManData();
        MessageBox.Show("افزودن دانشجو با موفقیت انجام شد");
    }

    private void StudentDg_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is DataRowView selectedDataRowView)
        {
            StudentIdTb.Text = selectedDataRowView.Row["StID"].ToString();
            StudentNameTb.Text = selectedDataRowView.Row["StName"].ToString();
            StudentFamilyTb.Text = selectedDataRowView.Row["StFamily"].ToString();
            StudentField.Text = selectedDataRowView.Row["StField"].ToString();
        }
    }

    private void ModernSearch_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"select * from Student where StID like '{ModernSearch.Text}%' and IsActive = 1" ;
        StudentDg.ItemsSource = md.ShowData().DefaultView;
        StudentDg.Columns[4].Visibility = Visibility.Collapsed;
    }

    private void SearchStudentBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"select * from Student where StID = '{StudentIdTb.Text}' and IsActive = 'true'";
        DataTable dt = md.ShowData();
        StudentDg.ItemsSource = dt.DefaultView;
        StudentDg.Columns[4].Visibility = Visibility.Collapsed;

        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            StudentIdTb.Text = row["StID"].ToString();
            StudentNameTb.Text = row["StName"].ToString();
            StudentFamilyTb.Text = row["StFamily"].ToString();
            StudentField.Text = row["StField"].ToString();
        }
        else
        {
            MessageBox.Show("There is no students with that ID");
        }
    }

    private void StudentDeleteBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"update Student set IsActive = 0 where StID =N'{StudentIdTb.Text}'";
        
        if (StudentIdTb.Text == "")
        {
            MessageBox.Show("لطفا یک سطر را برای حذف انتخاب کنید");
        }
        else
        {
            md.ManData();
            MessageBox.Show("با موفقیت حذف شد");
        }    
    }
        

    private void EditStudentBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData(); 
        
        DataRowView selectedDataRowView = StudentDg.SelectedItem as DataRowView;
        
        if (selectedDataRowView != null)
        {
            string TempStID = selectedDataRowView.Row["StID"].ToString(); 

            md.Command = $"UPDATE Student SET StID=N'{StudentIdTb.Text}', StName=N'{StudentNameTb.Text}', " + 
                         $"StFamily=N'{StudentFamilyTb.Text}', StField=N'{StudentField.Text}' " + 
                         $"WHERE StID=N'{TempStID}'";
            md.ManData();
            MessageBox.Show("دانشجو با موفقیت ویرایش شد");
        }
        else
        {
            MessageBox.Show("لطفاً یک سطر را برای ویرایش انتخاب کنید.");
        }
    }

    private void CleanBtn_OnClick(object sender, RoutedEventArgs e)
    {
        StudentIdTb.Text = null;
        StudentNameTb.Text = null;
        StudentFamilyTb.Text = null;
        StudentField.Text = null;
    }
}