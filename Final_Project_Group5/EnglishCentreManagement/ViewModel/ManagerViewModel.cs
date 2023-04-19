using EnglishCentreManagement.Database;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.CodeDom.Compiler;
using System.Threading;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class ManagerViewModel : BaseViewModel
    {
        private UserAccount _currentUserAccount;
        private IEnterprise_infoDAO enterprise_InfoDAO;
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
            //enterprise_InfoDAO = new Enterprise_infoDAO();
            //LoadUserCurrentData();
            ShowHomeView = new RelayCommand<object>(ExecuteShowHomeViewCommand);
            ShowUserInforView = new RelayCommand<object>(ExecuteShowUserInforViewCommand);
            ShowManageClassroomView = new RelayCommand<object>(ExecuteShowManageClassroomViewCommand);
            ShowAddStudentView = new RelayCommand<object>(ExecuteShowAddStudentViewCommand);
            ShowAddTeacherView = new RelayCommand<object>(ExecuteShowAddTeacherViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);
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

        public UserAccount CurrentUserAccount 
        { 
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        //private void LoadUserCurrentData()
        //{
        //    var user = enterprise_InfoDAO.getByUserName(Thread.CurrentPrincipal.Identity.Name);
        //    if(user  != null)
        //    {
        //        CurrentUserAccount = new UserAccount()
        //        {
        //            Username = user.UserName,
        //            Displayname = user.getNameOfUser(),
        //        }
        //    }
        //}

        private void ExecuteShowHomeViewCommand(object? p)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = PackIconKind.Home;
        }

        private void ExecuteShowManageClassroomViewCommand(object? p)
        {
            CurrentChildView = new ManageClassroomViewModel();
            Caption = "Manage classroom";
            Icon = PackIconKind.GoogleClassroom;
        }

        private void ExecuteShowAddStudentViewCommand(object? p)
        {
            CurrentChildView = new AddStudentViewModel();
            Caption = "Add student";
            Icon = PackIconKind.AccountSchoolOutline;
        }

        private void ExecuteShowAddTeacherViewCommand(object? p)
        {
            CurrentChildView = new AddTeacherViewModel();
            Caption = "Add teacher";
            Icon = PackIconKind.HumanMaleBoard;
        }

        private void ExecuteShowUserInforViewCommand(object? p)
        {
            CurrentChildView = new UserInforViewModel();
            Caption = "User information";
            Icon = PackIconKind.AccountBoxOutline;
        }

    }
}
