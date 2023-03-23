using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        public ICommand UserInforCommand { get; set; }
        public ICommand CloseWindow { get; set; }
        public ControlBarViewModel()
        {
            UserInforCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserInformationWindow q = new UserInformationWindow(); q.ShowDialog(); });
            CloseWindow = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
        }
    }
}
