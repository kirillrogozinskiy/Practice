﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;

namespace WpfApp
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeService _employeeService;
        private ObservableCollection<EmployeeModel> _employees;
        private List<DepartmentModel> _departments;
        private EmployeeModel _selectedEmployee;
        private string _filterDepartment = "Все";
        private bool _isLoading;
        private int _progressValue;

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

        public ICommand AddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand SaveDataCommand { get; }
        public ICommand FilterCommand { get; }

        public EmployeeViewModel()
        {
            _employeeService = new EmployeeService();
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
                return string.Equals(employee.Department, FilterDepartment, StringComparison.OrdinalIgnoreCase);

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
            var newEmployee = new EmployeeModel();
            if (ShowEmployeeDialog(newEmployee))
            {
                Employees.Add(newEmployee);
                SaveDataAsync().ConfigureAwait(false);
            }
        }

        private void EditEmployee(object obj)
        {
            if (SelectedEmployee == null) return;

            var employeeCopy = new EmployeeModel
            {
                FullName = SelectedEmployee.FullName,
                Position = SelectedEmployee.Position,
                Department = SelectedEmployee.Department
            };

            if (ShowEmployeeDialog(employeeCopy))
            {
                SelectedEmployee.FullName = employeeCopy.FullName;
                SelectedEmployee.Position = employeeCopy.Position;
                SelectedEmployee.Department = employeeCopy.Department;
                SaveDataAsync().ConfigureAwait(false);
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
                Employees.Remove(SelectedEmployee);
                SaveDataAsync().ConfigureAwait(false);
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
                var progress = new Progress<int>(value => ProgressValue = value);
                var employeesTask = _employeeService.LoadEmployeesAsync(progress);
                var departmentsTask = _employeeService.LoadDepartmentsAsync();

                await Task.WhenAll(employeesTask, departmentsTask);

                Employees = await employeesTask;
                Departments = await departmentsTask;
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
            try
            {
                await _employeeService.SaveEmployeesAsync(Employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
