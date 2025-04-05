using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Services;

namespace WpfApp.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly AuthService _authService;
        private readonly Window _window;
        private string _username;
        private string _department;

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

        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        public List<string> Departments { get; } = new List<string> { "HR", "IT", "Финансы", "Маркетинг" };

        public ICommand RegisterCommand { get; }

        public RegisterViewModel(Window window)
        {
            _authService = new AuthService();
            _window = window;
            RegisterCommand = new RelayCommand(RegisterAsync, CanRegister);
        }

        private bool CanRegister(object parameter) => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Department);

        private async void RegisterAsync(object parameter)
        {
            if (parameter is PasswordBox passwordBox)
            {
                var success = await _authService.RegisterUserAsync(Username, passwordBox.Password, Department);
                if (success)
                {
                    MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    _window.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}