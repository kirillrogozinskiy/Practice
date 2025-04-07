namespace WpfApp
{
    public class EmployeeModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}