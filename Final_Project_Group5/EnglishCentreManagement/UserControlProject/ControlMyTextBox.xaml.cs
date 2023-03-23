using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnglishCentreManagement.UserControlProject
{
    /// <summary>
    /// Interaction logic for UserMyTextBox.xaml
    /// </summary>
    public partial class UserMyTextBox : UserControl
    {
        public UserMyTextBox()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty HintProperty = DependencyProperty.Register
    ("Hint", typeof(string), typeof(UserMyTextBox));
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
    }

}
