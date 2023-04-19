using EnglishCentreManagement.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        private BaseViewModel _currentChildView;
        private string _caption;
        private PackIconKind _icon;
        private Student _currentStudent;

        public ICommand ShowHomeView { get; }
        public ICommand ShowRegisterClassView { get;}
        public ICommand ShowYourClassView { get;}
        public ICommand ShowYourTestView { get;}
        public ICommand ShowYourScheduleView { get;}
        public ICommand ShowUserInfoView { get;}

        public StudentViewModel()
        {
            ShowHomeView = new RelayCommand<object>(ExecuteShowHomeViewModel);
            ShowRegisterClassView = new RelayCommand<object>(ExecuteShowRegisterClassView);
            ShowUserInfoView = new RelayCommand<object>(ExecuteShowUserInfoView);

            ExecuteShowHomeViewModel(null);
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
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public Student CurrentStudent 
        { 
            get => _currentStudent; 
            set
            {
                _currentStudent = value;
                OnPropertyChanged(nameof(CurrentStudent));
            }
        }

        private void ExecuteShowHomeViewModel(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = PackIconKind.Home;
        }

        private void ExecuteShowRegisterClassView(object obj)
        {

            CurrentChildView = new RegisterViewModel(CurrentStudent);
            Caption = "Register class";
            Icon = PackIconKind.ClipboardEditOutline;
        }

        private void ExecuteShowUserInfoView(object obj)
        {
            CurrentChildView = new UserInforViewModel();
            Caption = "User information";
            Icon = PackIconKind.AccountBoxOutline;
        }

    }
}
