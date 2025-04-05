using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class LoginWindow : Window
    {
        private readonly UserService _userService = new UserService();
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            var user = await _userService.AuthenticateUserAsync(username, password);
            if (user != null)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerPage = new RegisterWindow();
            registerPage.Show();
            this.Close();
        }
    }
}