using System.Windows;
using WpfApp.Model;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    public partial class MainWindow : Window
    {
        public MainWindow(UserModel user)
        {
            InitializeComponent();
            var viewModel = new EmployeeViewModel(user);
            DataContext = viewModel;

            // Hook into the Closing event to dispose the ViewModel
            this.Closing += (sender, e) =>
            {
                if (DataContext is IDisposable disposableViewModel)
                {
                    disposableViewModel.Dispose();
                }
            };
        }
    }
}
