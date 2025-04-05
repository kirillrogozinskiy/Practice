using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(this);
        }
    }
}