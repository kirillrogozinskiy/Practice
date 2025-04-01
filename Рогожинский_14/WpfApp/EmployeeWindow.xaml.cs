using System.Windows;

namespace WpfApp
{
    public partial class EmployeeWindow : Window
    {
        public MainWindow.Employee Employee { get; private set; }

        public EmployeeWindow(MainWindow.Employee employee = null)
        {
            InitializeComponent();
            Employee = employee ?? new MainWindow.Employee();
            DataContext = this;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Employee.FullName) ||
                string.IsNullOrWhiteSpace(Employee.Position))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}