using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using fr_fr_sama_project.DataManagement;

namespace fr_fr_sama_project;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    private void Exit_BTN_OnClick(object sender, RoutedEventArgs e)
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


    private void MainWindowDrag_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            this.DragMove();
    }
    
}