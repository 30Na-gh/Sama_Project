using fr_fr_sama_project.Core;

namespace fr_fr_sama_project.MVVM.UViewModel;

public class UMainViewModel : ObservableObject
{
    public RelayCommand UHomeViewCommand { get; set; }
    public RelayCommand UStudentViewCommand { get; set; }
    public RelayCommand UTeacherViewCommand { get; set; }
    public RelayCommand UGradeViewCommand { get; set; }
    public RelayCommand UCourseViewCommand { get; set; }
    
    public UHomeViewModel UHomeVm{get;set;}
    public UStudentViewModel UStudentVm{get;set;}
    public UTeacherViewModel UTeacherVm{get;set;}
    public UGradeViewModel UGradeVm{get;set;}
    public UCourseViewModel UCourseVm{get;set;}
    
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

    public UMainViewModel()
    {
        UHomeVm = new UHomeViewModel();
        UStudentVm = new UStudentViewModel();
        UTeacherVm = new UTeacherViewModel();
        UGradeVm = new UGradeViewModel();
        UCourseVm = new UCourseViewModel();
        
        CurrentView = UHomeVm;
        
        UHomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = UHomeVm;
        });
        
        UStudentViewCommand = new RelayCommand(o =>
        {
            CurrentView = UStudentVm;
        });
        
        UTeacherViewCommand = new RelayCommand(o =>
        {
            CurrentView = UTeacherVm;
        });
        
        UGradeViewCommand = new RelayCommand(o =>
        {
            CurrentView = UGradeVm;
        });
        
        UCourseViewCommand = new RelayCommand(o =>
        {
            CurrentView = UCourseVm;
        });
    }
}