using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp
{
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        public List<string> Departments { get; } = new List<string> { "HR", "IT", "Финансы", "Маркетинг" };

        public EmployeeWindow(Employee employee = null)
        {
            InitializeComponent();
            Employee = employee ?? new Employee();
            DataContext = this;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Employee.FullName) ||
                string.IsNullOrWhiteSpace(Employee.Position) ||
                string.IsNullOrWhiteSpace(Employee.Department))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }

    public class Employee
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}