using fr_fr_sama_project.Core;

namespace fr_fr_sama_project.MVVM.ViewModel;

class MainViewModel : ObservableObject 
{
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand StudentViewCommand { get; set; }
    public RelayCommand TeacherViewCommand { get; set; }
    public RelayCommand CourseViewCommand { get; set; }
    public RelayCommand GradeViewCommand { get; set; }
    
    public HomeViewModel HomeVm { get; set; }
    public StudentViewModel StudentVm { get; set; }
    public TeacherViewModel TeacherVm { get; set; }
    public CourseViewModel CourseVm { get; set; }
    public GradeViewModel GradeVm { get; set; }
    
    private object _CurrentView;

    public object CurrentView
    {
        get { return _CurrentView; }
        set
        {
            _CurrentView = value; 
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        HomeVm = new HomeViewModel();
        StudentVm = new StudentViewModel();
        TeacherVm = new TeacherViewModel();
        CourseVm = new CourseViewModel();
        GradeVm = new GradeViewModel();

        CurrentView = HomeVm;

        HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVm; });

        StudentViewCommand = new RelayCommand(o => { CurrentView = StudentVm; });

        TeacherViewCommand = new RelayCommand(o => { CurrentView = TeacherVm; });

        CourseViewCommand = new RelayCommand(o => { CurrentView = CourseVm; });
        
        GradeViewCommand = new RelayCommand(o => { CurrentView = GradeVm; });
    }
}