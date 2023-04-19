using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //public bool isLoaded = false;
        //public ICommand LoadedWindowCommand { get; set; }
        //public MainViewModel()
        //{
        //    LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
        //    {
        //        isLoaded = true;
        //        if (p == null)
        //            return;
        //        p.Hide();
        //        LoginWindow loginWindow = new LoginWindow();
        //        loginWindow.ShowDialog();
        //        if (loginWindow.DataContext == null)
        //            return;

        //        var loginVM = loginWindow.DataContext as LoginViewModel;
        //        if (loginVM == null)
        //            return;
        //        if (loginVM.IsLogin)
        //        {
        //            if (loginWindow.lbiStudent.IsSelected)
        //            {
        //                StudentWindow q = new StudentWindow();
        //                q.Show();
        //            }
        //            else if (loginWindow.lbiTeacher.IsSelected)
        //            {
        //                TeacherWindow q = new TeacherWindow();
        //                q.Show();
        //            }
        //            else
        //            {
        //                ManagerWindow q = new ManagerWindow();
        //                q.Show();
        //            }
        //            p.Close();
        //        }
        //        else
        //        {
        //            p.Close();
        //        }
        //    });
        //}
    }
}
