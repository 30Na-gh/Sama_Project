using System.Data;
using System.Windows;
using System.Windows.Controls;
using fr_fr_sama_project.DataManagement;
using fr_fr_sama_project.DataManagement.Validators;
using fr_fr_sama_project.entities;

namespace fr_fr_sama_project.MVVM.View;

public partial class CourseView : UserControl
{
    public CourseView()
    {
        InitializeComponent();
        CourseUnitTb.Text = "0";
    }

    private void AddCourseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Course c1 = new Course(
             Convert.ToString(CourseIdTb.Text),
             Convert.ToString(CourseNameTb.Text),
             Convert.ToString(CourseTypeTb.Text),
             Convert.ToInt32(CourseUnitTb.Text),
             true);
        CourseValidator CVa = new CourseValidator();
        if (CVa.Validate(c1) == false)
        {
            MessageBox.Show("Error");
            return;
        }
        MyData md = new MyData();
        md.Command = $"insert into Course (CID, CName, CType, CUnit, IsActive) values " +
                     $"(N'{c1.CID}',N'{c1.CName}',N'{c1.CType}',N'{c1.CUnit}','{c1.IsActive}')";
        md.ManData();
        MessageBox.Show("درس با موفقیت ثبت شد");
    }

    private void CourseDg_OnLoaded(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select * from Course where IsActive='true'";
        CourseDg.ItemsSource = md.ShowData().DefaultView;
        CourseDg.Columns[4].Visibility = Visibility.Collapsed;
    }

    private void CourseEditBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        DataRowView selectedDataRowView = CourseDg.SelectedItem as DataRowView;
        if (selectedDataRowView != null)
        {
            string TempCID = selectedDataRowView.Row["CID"].ToString();
            if (CourseIdTb.Text == "")
            {
                MessageBox.Show("یک سطر را برای ویرایش انتخاب کنید");
                return;
            }

            md.Command = $"UPDATE Course SET " +
                         $"CID=N'{CourseIdTb.Text}', CName=N'{CourseNameTb.Text}', CType=N'{CourseTypeTb.Text}', CUnit=N'{CourseUnitTb.Text}'" + 
                         $"WHERE CID=N'{TempCID}'";
            md.ManData();
            MessageBox.Show("درس با موفقیت ویرایش شد");
        }
        else
        {
            MessageBox.Show("لطفاً یک سطر را برای ویرایش انتخاب کنید.");
        }
    }

    private void CourseDg_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is DataRowView selectedDataRowView)
        {
            CourseIdTb.Text = selectedDataRowView.Row["CID"].ToString();
            CourseNameTb.Text = selectedDataRowView.Row["CName"].ToString();
            CourseTypeTb.Text = selectedDataRowView.Row["CType"].ToString();
            CourseUnitTb.Text = selectedDataRowView.Row["CUnit"].ToString();
        }
    }

    private void CourseDeleteBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"update Course set IsActive = 0 where CID =N'{CourseIdTb.Text}'";
        if (CourseIdTb.Text == "")
        {
            MessageBox.Show("لطفا یک سطر را برای حذف انتخاب کنید");
        }
        else
        {
            md.ManData();
            MessageBox.Show("با موفقیت حذف شد");
        }
    }

    private void CourseSearchBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"select * from Course where CID = '{CourseIdTb.Text}' and IsActive = 'true'";
        DataTable dt = md.ShowData();
        CourseDg.ItemsSource = dt.DefaultView;
        CourseDg.Columns[4].Visibility = Visibility.Collapsed;

        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            CourseIdTb.Text = row["CID"].ToString();
            CourseNameTb.Text = row["CName"].ToString();
            CourseTypeTb.Text = row["CType"].ToString();
            CourseUnitTb.Text = row["CUnit"].ToString(); 
        }
        else
        {
            MessageBox.Show("درسی با این کد درس یافت نشد");
        }
    }

    private void ShowCourseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select * from Course where IsActive = 1";
        CourseDg.ItemsSource = md.ShowData().DefaultView;
        CourseDg.Columns[4].Visibility = Visibility.Collapsed;
        MessageBox.Show("لیست دروس با موفقیت به روزرسانی شد");
    }

    private void CourseUnitTb_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CourseUnitTb.Text))
        {
            CourseUnitTb.Text = "0";
        }   
    }

    private void ModernSearch_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = $"select * from Course where CID like '{ModernSearch.Text}%' and IsActive = 1" ;
        CourseDg.ItemsSource = md.ShowData().DefaultView;
        CourseDg.Columns[4].Visibility = Visibility.Collapsed;
    }

    private void CleanBtn_OnClick(object sender, RoutedEventArgs e)
    {
        CourseIdTb.Text = "";
        CourseNameTb.Text = "";
        CourseTypeTb.Text = "";
        CourseUnitTb.Text = "0";
    }
}