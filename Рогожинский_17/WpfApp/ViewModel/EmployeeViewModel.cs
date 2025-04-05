using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp.Model;
using WpfApp.Services;
using WpfApp.View;

namespace WpfApp.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly EmployeeService _employeeService;
        private readonly ChatService _chatService;
        private readonly NotificationService _notificationService;
        private readonly UserModel _currentUser;

        // --- Fields ---
        // Initialize collections and strings to avoid nullability warnings
        private ObservableCollection<EmployeeModel> _allEmployees = new ObservableCollection<EmployeeModel>();
        private ObservableCollection<string> _chatMessages = new ObservableCollection<string>();
        private string _chatMessage = string.Empty; // Initialize non-nullable string
        private string _filterDepartment = "Все";

        // Nullable fields are appropriate here
        private EmployeeModel? _selectedEmployee; // Selection can be null
        private bool _isLoading;
        private bool _isDisposed = false;

        // --- Events ---
        // Match INotifyPropertyChanged nullability
        public event PropertyChangedEventHandler? PropertyChanged;

        // --- Properties ---
        // Store the source data
        public ObservableCollection<EmployeeModel> AllEmployees
        {
            get => _allEmployees;
            private set // Make setter private or protected if only modified internally
            {
                _allEmployees = value;
                // Recreate or refresh the view when the source changes
                EmployeesView = CollectionViewSource.GetDefaultView(_allEmployees);
                EmployeesView.Filter = FilterEmployees;
                OnPropertyChanged(nameof(AllEmployees)); // Notify source collection changed
                OnPropertyChanged(nameof(EmployeesView)); // Notify view changed
            }
        }

        // The view used for binding in the UI (handles filtering/sorting)
        // Initialize in constructor after AllEmployees is set
        public ICollectionView EmployeesView { get; private set; }

        public ObservableCollection<string> ChatMessages
        {
            get => _chatMessages;
            set // Usually only set internally or once at init
            {
                _chatMessages = value;
                OnPropertyChanged(nameof(ChatMessages));
            }
        }

        // Selection property MUST be nullable
        public EmployeeModel? SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                // Use the new method on RelayCommand
                EditEmployeeCommand.RaiseCanExecuteChanged();
                DeleteEmployeeCommand.RaiseCanExecuteChanged();
            }
        }

        public string FilterDepartment
        {
            get => _filterDepartment;
            set
            {
                if (_filterDepartment != value)
                {
                    _filterDepartment = value;
                    OnPropertyChanged(nameof(FilterDepartment));
                    EmployeesView?.Refresh(); // Use null-conditional access
                }
            }
        }

        // Initialize non-nullable string property
        public string ChatMessage
        {
            get => _chatMessage;
            set
            {
                _chatMessage = value ?? string.Empty; // Ensure value isn't null
                OnPropertyChanged(nameof(ChatMessage));
                SendChatMessageCommand.RaiseCanExecuteChanged(); // Update CanExecute
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
                // Update commands that depend on loading state
                SaveDataCommand.RaiseCanExecuteChanged();
                EditEmployeeCommand.RaiseCanExecuteChanged();
                DeleteEmployeeCommand.RaiseCanExecuteChanged();
                SendChatMessageCommand.RaiseCanExecuteChanged();
                // Add/Filter commands might also depend on IsLoading
                AddEmployeeCommand.RaiseCanExecuteChanged();
                FilterCommand.RaiseCanExecuteChanged(); // If filtering is disabled during load
            }
        }

        // Use RelayCommand type directly for RaiseCanExecuteChanged
        public RelayCommand AddEmployeeCommand { get; }
        public RelayCommand EditEmployeeCommand { get; }
        public RelayCommand DeleteEmployeeCommand { get; }
        public RelayCommand SaveDataCommand { get; }
        public RelayCommand FilterCommand { get; }
        public RelayCommand SendChatMessageCommand { get; }
        public RelayCommand CloseCommand { get; }

        public EmployeeViewModel(UserModel user)
        {
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            _employeeService = new EmployeeService();
            _notificationService = new NotificationService();
            _chatService = new ChatService(user.Department); // Initialize NEW ChatService

            // Initialize EmployeesView after AllEmployees is initialized
            EmployeesView = CollectionViewSource.GetDefaultView(_allEmployees);
            EmployeesView.Filter = FilterEmployees;


            // Initialize Commands (pass object? parameter type)
            AddEmployeeCommand = new RelayCommand(AddEmployee, CanExecuteWhenNotLoading);
            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEditDeleteEmployee);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee, CanEditDeleteEmployee);
            SaveDataCommand = new RelayCommand(async _ => await SaveDataAsync(), CanExecuteWhenNotLoading);
            FilterCommand = new RelayCommand(ApplyFilter, CanExecuteWhenNotLoading); // Can filter when not loading
            SendChatMessageCommand = new RelayCommand(SendChatMessageAsync, CanSendChatMessage);
            CloseCommand = new RelayCommand(_ => Application.Current.Shutdown()); // Consider disposing resources here too

            // Subscribe to ChatService event
            _chatService.MessageReceived += OnChatMessageReceived;

            // Start loading data and chat listener
            LoadDataAsync(); // Fire and forget async load
            _chatService.StartListening(); // Start listening for chat messages
        }

        // --- Command CanExecute Methods ---

        // Parameter type must be object? to match RelayCommand/ICommand
        private bool CanExecuteWhenNotLoading(object? parameter) => !_isLoading;
        private bool CanEditDeleteEmployee(object? parameter) => SelectedEmployee != null && !_isLoading;
        private bool CanSendChatMessage(object? parameter) => !string.IsNullOrWhiteSpace(ChatMessage) && !_isLoading;

        // --- Filtering ---
        // Parameter type must be object? but often cast
        private bool FilterEmployees(object item) // This is correct for CollectionView Filter predicate
        {
            if (string.IsNullOrWhiteSpace(FilterDepartment) || FilterDepartment == "Все")
                return true;

            if (item is EmployeeModel employee)
            {
                return string.Equals(employee.Department, FilterDepartment, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // Parameter type must be object?
        private void ApplyFilter(object? parameter)
        {
            if (parameter is string department)
            {
                FilterDepartment = department;
            }
        }

        // --- CRUD Methods ---
        // Parameter type must be object?
        private async void AddEmployee(object? parameter)
        {
            if (_isLoading) return; // Prevent action while loading

            var departments = await _employeeService.LoadDepartmentsAsync();
            var deptNames = departments.Select(d => d.Name).ToList();

            var newEmployee = new EmployeeModel { Department = _currentUser.Department };
            if (ShowEmployeeDialog(newEmployee, deptNames))
            {
                AllEmployees.Add(newEmployee); // Add to the backing collection
                // EmployeesView should update automatically
                _notificationService.SendNotification($"Добавлен сотрудник: {newEmployee.FullName}");
                await SaveDataAsync();
            }
        }

        // Parameter type must be object?
        private async void EditEmployee(object? parameter)
        {
            if (SelectedEmployee == null || _isLoading) return; // Check IsLoading here too

            var departments = await _employeeService.LoadDepartmentsAsync();
            var deptNames = departments.Select(d => d.Name).ToList();

            var employeeCopy = new EmployeeModel
            {
                FullName = SelectedEmployee.FullName,
                Position = SelectedEmployee.Position,
                Department = SelectedEmployee.Department
            };

            if (ShowEmployeeDialog(employeeCopy, deptNames))
            {
                // Apply changes back
                SelectedEmployee.FullName = employeeCopy.FullName;
                SelectedEmployee.Position = employeeCopy.Position;
                SelectedEmployee.Department = employeeCopy.Department;

                // Refresh view explicitly if needed (e.g., if sorting/filtering depends on modified props)
                EmployeesView?.Refresh();

                _notificationService.SendNotification($"Изменен сотрудник: {SelectedEmployee.FullName}");
                await SaveDataAsync();
            }
        }

        // Parameter type must be object?
        private async void DeleteEmployee(object? parameter)
        {
            if (SelectedEmployee == null || _isLoading) return;

            var result = MessageBox.Show($"Удалить сотрудника {SelectedEmployee.FullName}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string deletedName = SelectedEmployee.FullName;
                AllEmployees.Remove(SelectedEmployee); // Remove from backing collection
                                                       // EmployeesView should update automatically
                _notificationService.SendNotification($"Удален сотрудник: {deletedName}");
                await SaveDataAsync();
            }
        }

        // Helper adjusted for clarity
        private bool ShowEmployeeDialog(EmployeeModel employee, List<string> departmentNames)
        {
            if (departmentNames == null || !departmentNames.Any())
            {
                departmentNames = new List<string> { "HR", "IT", "Финансы", "Маркетинг" }; // Fallback
            }

            var dialog = new EmployeeWindow(employee, departmentNames);
            // Consider setting Owner for modality relative to main window
            // dialog.Owner = Application.Current.MainWindow;
            return dialog.ShowDialog() ?? false;
        }


        // --- Data Loading and Saving ---
        private async void LoadDataAsync()
        {
            if (_isLoading) return;
            IsLoading = true;

            try
            {
                var progressIndicator = new Progress<int>(ReportProgress);
                var loadedEmployees = await _employeeService.LoadEmployeesAsync(progressIndicator);

                // Update on UI thread
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Replace the contents of the existing collection or create new view
                    AllEmployees = loadedEmployees; // This setter handles EmployeesView update
                    Console.WriteLine($"Loaded {AllEmployees.Count} employees.");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных сотрудников: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    AllEmployees.Clear(); // Clear on error maybe? Or leave old data?
                    EmployeesView?.Refresh();
                });
            }
            finally
            {
                Application.Current.Dispatcher.Invoke(() => IsLoading = false); // Ensure IsLoading is set on UI thread if bound
                ReportProgress(0); // Reset progress visual
            }
        }

        private void ReportProgress(int value)
        {
            Console.WriteLine($"Loading progress: {value}%");
        }

        private async Task SaveDataAsync()
        {
            if (_isLoading) return; // Prevent saving while loading/another save is in progress

            IsLoading = true;
            try
            {
                // Create a stable copy for saving in case collection is modified during await
                var employeesToSave = new ObservableCollection<EmployeeModel>(AllEmployees);
                await _employeeService.SaveEmployeesAsync(employeesToSave);
                Console.WriteLine("Employee data saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных сотрудников: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }


        // --- Chat Methods ---
        // Parameter type must be object?
        private async void SendChatMessageAsync(object? parameter)
        {
            if (!CanSendChatMessage(parameter)) return; // Re-check CanExecute logic here

            string messageToSend = ChatMessage;
            ChatMessage = string.Empty; // Clear input box

            var fullMessage = $"{_currentUser.Username}: {messageToSend}";

            try
            {
                // SendMessageAsync should handle potential exceptions internally if possible
                await _chatService.SendMessageAsync(fullMessage);
                // Message display is handled by OnChatMessageReceived
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending chat message: {ex.Message}");
                Application.Current.Dispatcher.Invoke(() =>
                     ChatMessages.Add($"[Ошибка отправки: {ex.Message}]"));
                // Maybe restore message to input box?
                // ChatMessage = messageToSend;
            }
        }

        private void OnChatMessageReceived(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (_isDisposed) return;
                ChatMessages.Add(message);
            });
        }

        // --- INotifyPropertyChanged ---
        protected void OnPropertyChanged(string propertyName)
        {
            // Use null-conditional invocation
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // --- IDisposable ---
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                Console.WriteLine("Disposing EmployeeViewModel...");
                _chatService.MessageReceived -= OnChatMessageReceived;
                _chatService?.Dispose(); // Use null-conditional
                Console.WriteLine("EmployeeViewModel disposed.");
            }

            _isDisposed = true;
        }
    }
}