using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace fr_fr_sama_project.MVVM.View;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void DormitoryBTN_OnClick(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start(new ProcessStartInfo
        {
            FileName = "https://dorm.uut.ac.ir:81/",
            UseShellExecute = true
        });
    }

    private void FoodBTN_OnClick(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start(new ProcessStartInfo
        {
            FileName = "https://food.uut.ac.ir/",
            UseShellExecute = true
        });
    }


    private void EmailBTN_OnClick(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start(new ProcessStartInfo
        {
            FileName = "https://uut.ac.ir/webmail",
            UseShellExecute = true
        });
    }

    private void SiteBTN_OnClick(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start(new ProcessStartInfo
        {
            FileName = "https://uut.ac.ir/",
            UseShellExecute = true
        });
    }
}