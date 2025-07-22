using System.Data;
using System.Windows;
using System.Windows.Controls;
using fr_fr_sama_project.DataManagement;
using fr_fr_sama_project.DataManagement.Validators;
using fr_fr_sama_project.entities;

namespace fr_fr_sama_project.MVVM.View;

public partial class GradeView : UserControl
{
    public GradeView()
    {
        InitializeComponent();
        TermNoTb.Text = "0";
        GradeTb.Text = "0";
    }

    private void StudentIdCb_OnDropDownOpened(object? sender, EventArgs e)
    {
        
            MyData md = new MyData();
            md.Command = "select StId, StName, StFamily from Student where IsActive = 1";
            DataTable dt = md.ShowData();

            List<Student> students = new();
            foreach (DataRow row in dt.Rows)
            {
                students.Add(new Student
                {
                    ID = row["StId"].ToString(),
                    Name = row["StName"].ToString(),
                    Family = row["StFamily"].ToString(),
                });
            }

            StudentIdCb.ItemsSource = students;
            StudentIdCb.DisplayMemberPath = "DisplayInfo";
            StudentIdCb.SelectedValuePath = "ID";
    }


    private void TeacherIdCb_OnDropDownOpened(object? sender, EventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select TID, TName, TFamily from Teacher where IsActive = 1";
        DataTable dt = md.ShowData();

        List<Teacher> teachers = new();
        foreach (DataRow row in dt.Rows)
        {
            teachers.Add(new Teacher
            {
                ID = row["TID"].ToString(),
                Name = row["TName"].ToString(),
                Family = row["TFamily"].ToString(),
            });
        }

        TeacherIdCb.ItemsSource = teachers;
        TeacherIdCb.DisplayMemberPath = "DisplayInfo";
        TeacherIdCb.SelectedValuePath = "ID";
    }

    private void CourseIdCb_OnDropDownOpened(object? sender, EventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select CID, CName, CType from Course where IsActive = 1";
        DataTable dt = md.ShowData();

        List<Course> courses = new();
        foreach (DataRow row in dt.Rows)
        {
            courses.Add(new Course
            {
                CID = row["CID"].ToString(),
                CName = row["CName"].ToString(),
                CType = row["CType"].ToString(),
            });
        }

        CourseIdCb.ItemsSource = courses;
        CourseIdCb.DisplayMemberPath = "DisplayInfo";
        CourseIdCb.SelectedValuePath = "CID";
    }

    private void AddGradeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        string studentId = StudentIdCb.SelectedValue.ToString();
        string teacherId = TeacherIdCb.SelectedValue?.ToString();
        string courseId = CourseIdCb.SelectedValue?.ToString();
        
        STC stc1 = new STC(studentId,teacherId,courseId,Convert.ToInt32(TermNoTb.Text),Convert.ToInt32(GradeTb.Text));
        
        GradeValidator GVA = new GradeValidator();
        if (GVA.Validate(stc1) == false)
        {
            MessageBox.Show("Error");
            return;
        }
        MyData md = new MyData();
        md.Command = $"insert into STC (StID, TID, CID, Term,Grade) values " +
                     $"(N'{stc1.StId}',N'{stc1.TId}',N'{stc1.CId}',N'{stc1.Term}','{stc1.Grade}')";
        md.ManData();
        MessageBox.Show("نمره با موفقیت ثبت شد");
    }

    private void GradeDg_OnLoaded(object sender, RoutedEventArgs e)
    {
        MyData md = new MyData();
        md.Command = "select * from STC";
        GradeDg.ItemsSource = md.ShowData().DefaultView;
    }
    
}