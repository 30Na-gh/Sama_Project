using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace fr_fr_sama_project.Core;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged? .Invoke(this, new PropertyChangedEventArgs(name));
    }
}