using System.Net.Http.Json;

namespace WinFormsAppConsuming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5202/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = client.GetAsync("api/Employees").Result;
                if (response.IsSuccessStatusCode)
                {
                    var EmployeeList = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                    dataGridView1.DataSource = EmployeeList;
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var Employees = await client.GetFromJsonAsync<List<Employee>>("http://localhost:5202/api/Employees");
                dataGridView1.DataSource = Employees;
            }
        }
    }
}
