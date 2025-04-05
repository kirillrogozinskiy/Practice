using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel(this);
        }
    }
}