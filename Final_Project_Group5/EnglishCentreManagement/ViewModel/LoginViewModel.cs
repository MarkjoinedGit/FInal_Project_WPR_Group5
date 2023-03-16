using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public LoginViewModel() 
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { onClickLogin(p); });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
        }   

        void onClickLogin(Window p)
        {
            if (p==null)
                return;
            IsLogin = true;
            p.Close();
        }
    }
}
