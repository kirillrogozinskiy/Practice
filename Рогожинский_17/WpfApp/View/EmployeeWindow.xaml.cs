using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp.Model; // Предполагается, что EmployeeModel находится в этом пространстве имен

namespace WpfApp.View
{
    public partial class EmployeeWindow : Window
    {
        public EmployeeModel Employee { get; private set; }
        public List<string> Departments { get; }

        public EmployeeWindow(EmployeeModel employee, List<string> departments)
        {
            InitializeComponent(); // Инициализация XAML
            Employee = employee;
            Departments = departments;
            DataContext = this; // Установка DataContext
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
            DialogResult = true; // Закрытие окна с положительным результатом
            Close(); // Явное закрытие окна
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Закрытие окна с отрицательным результатом
            Close(); // Явное закрытие окна
        }
    }
}