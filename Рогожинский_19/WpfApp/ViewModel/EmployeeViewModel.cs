using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace WpfApp
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeRepository _repository;
        private readonly HrContext _context; // Добавлено поле для хранения контекста
        private ObservableCollection<EmployeeModel> _allEmployees;
        private ObservableCollection<EmployeeModel> _employees;
        private List<DepartmentModel> _departments;
        private EmployeeModel _selectedEmployee;
        private string _filterDepartment = "Все";
        private bool _isLoading;
        private int _progressValue;
        private string _searchText;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<EmployeeModel> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
                EmployeesView = CollectionViewSource.GetDefaultView(_employees);
                EmployeesView.Filter = FilterEmployees;
            }
        }

        public ICollectionView EmployeesView { get; private set; }

        public List<DepartmentModel> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }

        public EmployeeModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                CommandManager.InvalidateRequerySuggested();
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
                    EmployeesView?.Refresh();
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public int ProgressValue
        {
            get => _progressValue;
            set
            {
                _progressValue = value;
                OnPropertyChanged(nameof(ProgressValue));
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                ApplySearchAndFilters();
            }
        }

        public ICommand AddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand SaveDataCommand { get; }
        public ICommand FilterCommand { get; }

        public EmployeeViewModel()
        {
            _context = new HrContext();
            _repository = new EmployeeRepository(_context);
            _allEmployees = new ObservableCollection<EmployeeModel>();
            Employees = new ObservableCollection<EmployeeModel>();
            Departments = new List<DepartmentModel>();

            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEditDeleteEmployee);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee, CanEditDeleteEmployee);
            LoadDataCommand = new RelayCommand(async _ => await LoadDataAsync());
            SaveDataCommand = new RelayCommand(async _ => await SaveDataAsync());
            FilterCommand = new RelayCommand(ApplyFilter);

            LoadDataAsync().ConfigureAwait(false);
        }

        private bool CanEditDeleteEmployee(object obj) => SelectedEmployee != null;

        private bool FilterEmployees(object obj)
        {
            if (string.IsNullOrWhiteSpace(FilterDepartment) || FilterDepartment == "Все")
                return true;

            if (obj is EmployeeModel employee)
                return string.Equals(employee.DepartmentModel?.Name, FilterDepartment, StringComparison.OrdinalIgnoreCase);

            return false;
        }

        private void ApplyFilter(object parameter)
        {
            if (parameter is string department)
            {
                FilterDepartment = department;
            }
        }

        private void AddEmployee(object obj)
        {
            var newEmployee = new EmployeeModel { IsAvailable = true };
            if (ShowEmployeeDialog(newEmployee))
            {
                newEmployee.DepartmentId = Departments.First(d => d.Name == newEmployee.Department).Id;
                _repository.AddEmployeeAsync(newEmployee).GetAwaiter().GetResult();
                _allEmployees.Add(newEmployee);
                ApplySearchAndFilters();
            }
        }

        private void EditEmployee(object obj)
        {
            if (SelectedEmployee == null) return;

            var employeeCopy = new EmployeeModel
            {
                Id = SelectedEmployee.Id,
                FullName = SelectedEmployee.FullName,
                Position = SelectedEmployee.Position,
                Department = SelectedEmployee.Department,
                DepartmentId = SelectedEmployee.DepartmentId,
                IsAvailable = SelectedEmployee.IsAvailable
            };

            if (ShowEmployeeDialog(employeeCopy))
            {
                SelectedEmployee.FullName = employeeCopy.FullName;
                SelectedEmployee.Position = employeeCopy.Position;
                SelectedEmployee.Department = employeeCopy.Department;
                SelectedEmployee.DepartmentId = Departments.First(d => d.Name == employeeCopy.Department).Id;
                _repository.UpdateEmployeeAsync(SelectedEmployee).GetAwaiter().GetResult();
                ApplySearchAndFilters();
            }
        }

        private void DeleteEmployee(object obj)
        {
            if (SelectedEmployee == null) return;

            var result = MessageBox.Show(
                $"Удалить сотрудника {SelectedEmployee.FullName}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _repository.DeleteEmployeeAsync(SelectedEmployee).GetAwaiter().GetResult();
                _allEmployees.Remove(SelectedEmployee);
                ApplySearchAndFilters();
            }
        }

        private bool ShowEmployeeDialog(EmployeeModel employee)
        {
            var dialog = new EmployeeWindow(employee, Departments.Select(d => d.Name).ToList());
            return dialog.ShowDialog() == true;
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;
            try
            {
                var employees = await _repository.GetEmployeesAsync();
                _allEmployees = new ObservableCollection<EmployeeModel>(employees);
                foreach (var emp in _allEmployees)
                {
                    emp.Department = emp.DepartmentModel?.Name ?? "Не указан";
                }
                ApplySearchAndFilters();
                Departments = await _context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task SaveDataAsync()
        {
            await Task.CompletedTask;
        }

        private void ApplySearchAndFilters()
        {
            Employees.Clear();
            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? _allEmployees
                : _allEmployees.Where(e => e.FullName.ToLower().Contains(SearchText.ToLower()));

            if (!string.IsNullOrWhiteSpace(FilterDepartment) && FilterDepartment != "Все")
            {
                filtered = filtered.Where(e => e.DepartmentModel?.Name == FilterDepartment);
            }

            foreach (var employee in filtered)
            {
                Employees.Add(employee);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}