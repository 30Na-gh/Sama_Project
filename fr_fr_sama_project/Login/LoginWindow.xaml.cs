using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;
using System.Windows;
using fr_fr_sama_project.DataManagement;

namespace fr_fr_sama_project.Login;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void ExitBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var fadeOut = new System.Windows.Media.Animation.DoubleAnimation
        {
            From = 1.0,
            To = 0.0,
            Duration = new Duration(TimeSpan.FromMilliseconds(150)),
            FillBehavior = System.Windows.Media.Animation.FillBehavior.HoldEnd
        };

        fadeOut.Completed += (s, a) =>
        {
            Application.Current.Shutdown();
        };

        this.BeginAnimation(Window.OpacityProperty, fadeOut);
    }

    private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
    {
        string password = PassWordTb.Password;
        MyData md = new MyData();
        md.Command =$"select * from Users where UName = '{UserNameTb.Text}' and UPass = '{password}'";
        DataTable dt = md.ShowData();
        if (dt.Rows.Count > 0)
        {
            string role = dt.Rows[0]["UType"].ToString();
            if (role == "مدیر")
            {
                MessageBox.Show("خوش امدید نقش شما: " + role);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (role == "کاربر")
            {
                MessageBox.Show("خوش امدید نقش شما: " + role);
                UserMainWindow userMainWindow = new UserMainWindow();
                userMainWindow.Show();
                this.Close();
            }
        }
        else
        {
            MessageBox.Show("نام کاربری یا رمز عبور اشتباه است");
        }
    }
}