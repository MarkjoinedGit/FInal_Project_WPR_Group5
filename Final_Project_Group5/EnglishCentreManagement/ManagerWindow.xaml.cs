using EnglishCentreManagement.ViewModel;
using System.Windows;

namespace EnglishCentreManagement
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            DataContext = new ManagerViewModel();
        }
    }
}
