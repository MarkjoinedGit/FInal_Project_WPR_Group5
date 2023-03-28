using MaterialDesignThemes.Wpf;
using System.CodeDom.Compiler;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class ManagerViewModel : BaseViewModel
    {
        private BaseViewModel _currentChildView;
        private string _caption;
        private PackIconKind _icon;
        public ICommand ShowHomeView { get; }
        public ICommand ShowManageClassroomView { get; }
        public ICommand ShowUserInforView { get; }
        public ICommand ShowAddStudentView { get; }
        public ICommand ShowAddTeacherView { get; }

    public ManagerViewModel()
        {
           
            ShowHomeView = new RelayCommand<object>((p) => { return true; }, (p) => { ExecuteShowHomeViewCommand(); });
            ShowUserInforView = new RelayCommand<object>((p) => { return true; }, (p) => { ExecuteShowUserInforViewCommand(); });
            ShowManageClassroomView = new RelayCommand<object>((p) => { return true; }, (p) => { ExecuteShowManageClassroomViewCommand(); });
            ShowAddStudentView = new RelayCommand<object>((p) => { return true; }, (p) => { ExecuteShowAddStudentViewCommand(); });
            ShowAddTeacherView = new RelayCommand<object>((p) => { return true; }, (p) => { ExecuteShowAddTeacherViewCommand(); });

            //Default view
            ExecuteShowHomeViewCommand();
        }

        private void ExecuteShowHomeViewCommand()
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = PackIconKind.Home;
        }

        private void ExecuteShowManageClassroomViewCommand()
        {
            CurrentChildView = new ManageClassroomViewModel();
            Caption = "Manage classroom";
            Icon = PackIconKind.GoogleClassroom;
        }

        private void ExecuteShowAddStudentViewCommand()
        {
            CurrentChildView = new AddStudentViewModel();
            Caption = "Add student";
            Icon = PackIconKind.AccountSchoolOutline;
        }

        private void ExecuteShowAddTeacherViewCommand()
        {
            CurrentChildView = new AddTeacherViewModel();
            Caption = "Add teacher";
            Icon = PackIconKind.HumanMaleBoard;
        }

        private void ExecuteShowUserInforViewCommand()
        {
            CurrentChildView = new UserInforViewModel();
            Caption = "User information";
            Icon = PackIconKind.AccountBoxOutline;
        }

        public BaseViewModel CurrentChildView 
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption 
        {
            get => _caption; 
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public PackIconKind Icon 
        { 
            get => _icon;
            set
            {
                _icon=value;
                OnPropertyChanged(nameof(Icon));
            }
        }
    }
}
