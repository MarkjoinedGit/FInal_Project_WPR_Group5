using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class TeacherViewModel : BaseViewModel
    {
        private IEnterprise_infoDAO enterprise_InfoDAO;
        private BaseViewModel _currentChildView;
        private string _caption;
        private PackIconKind _icon;
        private Teacher _crtTeacher;

        public ICommand ShowHomeView { get; }
        public ICommand ShowUserInforView { get; }

        public TeacherViewModel()
        {
            LoadUserCurrentData();
            ShowHomeView = new RelayCommand<object>(ExecuteShowHomeViewCommand);
            ShowUserInforView = new RelayCommand<object>(ExecuteShowUserInforViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);
        }

        private void LoadUserCurrentData()
        {
            _crtTeacher = CurrentUser.Instance.CurrentTeacher;
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

        public Teacher CrtTeacher
        {
            get => _crtTeacher;
            set
            {
                _crtTeacher=value;
                OnPropertyChanged(nameof(CrtTeacher));
            }
        }

        private void ExecuteShowHomeViewCommand(object? p)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = PackIconKind.Home;
        }

        private void ExecuteShowUserInforViewCommand(object? p)
        {
            CurrentChildView = new UserInforViewModel();
            Caption = "User information";
            Icon = PackIconKind.AccountBoxOutline;
        }

    }
}

