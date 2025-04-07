namespace WpfApp
{
    public class EmployeeModel
    {
        public int Id { get; set; } 
        public int DepartmentId { get; set; } 
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty; 
        public bool IsAvailable { get; set; }
        public DepartmentModel DepartmentModel { get; set; } 
    }
}