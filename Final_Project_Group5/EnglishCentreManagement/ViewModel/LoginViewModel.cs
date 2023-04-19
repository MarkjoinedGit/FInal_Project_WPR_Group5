using EnglishCentreManagement.Database;
using EnglishCentreManagement.Interfaces;
using System;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private string _role;
        private bool _isViewVisible = true;
        private IEnterprise_infoDAO enterprise_InfoDAO;

        public ICommand LoginCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public string Username 
        { 
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password 
        { 
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage 
        { 
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        { 
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public string Role { get => _role; set => _role=value; }

        //Constructors
        public LoginViewModel()
        {
            enterprise_InfoDAO = new Enterprise_infoDAO();
            LoginCommand = new RelayCommand<object>(CanExecuteLoginCommand, ExecuteLoginCommand);
        }

        private void ExecuteLoginCommand(object p)
        {
            var isValidUser = enterprise_InfoDAO.AuthenticateEnterpriseInfor(Username, Password);
            if(isValidUser) 
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }

            else
            {
                ErrorMessage = "* Username or Password is not correct";
            }
        }

        private bool CanExecuteLoginCommand(object p)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(Username) || Password == null)
                validData = false;
            else
                validData = true;
            return validData;
        }
    }
}
