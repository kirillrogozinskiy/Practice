using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Services;
using WpfApp.View;

namespace WpfApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly AuthService _authService;
        private readonly Window _window;
        private string _username;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ShowRegisterCommand { get; }

        public LoginViewModel(Window window)
        {
            _authService = new AuthService();
            _window = window;
            LoginCommand = new RelayCommand(LoginAsync, CanLogin);
            ShowRegisterCommand = new RelayCommand(ShowRegister);
        }

        private bool CanLogin(object parameter) => !string.IsNullOrWhiteSpace(Username);

        private async void LoginAsync(object parameter)
        {
            if (parameter is PasswordBox passwordBox)
            {
                var user = await _authService.LoginAsync(Username, passwordBox.Password);
                if (user != null)
                {
                    var mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    _window.Close();
                }
                else
                {
                    MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ShowRegister(object parameter)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}