using Newtonsoft.Json;

namespace task1
{
    public partial class Form1 : Form
    {

        private List<Employee> employees = new List<Employee>();
        private readonly string savePath = "employees.json";

        public Form1()
        {
            InitializeComponent();
            LoadData();
            UpdateDataGridView();
        }

        public class Employee
        {
            public string FullName { get; set; }
            public string Position { get; set; }
        }

        private void LoadData()
        {
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            }
        }

        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(savePath, json);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                employees.Add(new Employee
                {
                    FullName = textBox2.Text,
                    Position = textBox1.Text
                });

                UpdateDataGridView();
                ClearTextbox();
                SaveData();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateDataGridView(string filterPosition = null)
        {
            dataGridView1.Rows.Clear();

            var displayData = string.IsNullOrEmpty(filterPosition)
                ? employees
                : employees.FindAll(emp => emp.Position == filterPosition);

            foreach (var emp in displayData)
            {
                dataGridView1.Rows.Add(emp.FullName, emp.Position);
            }
        }

        private void ClearTextbox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Выберите строку для удаления!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = dataGridView1.CurrentRow.Cells[0].Value?.ToString();
            string position = dataGridView1.CurrentRow.Cells[1].Value?.ToString();

            Employee employeeToRemove = employees.Find(emp =>
                emp.FullName == fullName && emp.Position == position);

            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                UpdateDataGridView();
                SaveData();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) UpdateDataGridView();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) UpdateDataGridView("Менеджер");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) UpdateDataGridView("Разработчик");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Выберите строку для редактирования!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;

            string currentFullName = selectedRow.Cells[0].Value?.ToString();
            string currentPosition = selectedRow.Cells[1].Value?.ToString();

            Employee employeeToEdit = employees.Find(emp =>
                emp.FullName == currentFullName && emp.Position == currentPosition);

            if (employeeToEdit != null)
            {
                employeeToEdit.FullName = textBox2.Text;
                employeeToEdit.Position = textBox1.Text;

                UpdateDataGridView();
                SaveData(); 
                ClearTextbox();
            }
        }
    }
}
