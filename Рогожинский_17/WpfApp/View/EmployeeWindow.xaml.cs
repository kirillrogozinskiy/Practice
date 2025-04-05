using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp
{
    public partial class EmployeeWindow : Window
    {
        public EmployeeModel Employee { get; private set; }
        public List<string> Departments { get; }

        public EmployeeWindow(EmployeeModel employee, List<string> departments)
        {
            InitializeComponent();
            Employee = employee;
            Departments = departments;
            DataContext = this;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Employee.FullName) ||
                string.IsNullOrWhiteSpace(Employee.Position) ||
                string.IsNullOrWhiteSpace(Employee.Department))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}