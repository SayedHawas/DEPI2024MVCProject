using System.Net.Http.Headers;

namespace ConsoleAppConsuming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ShowEmployee(2);
            Console.ReadLine();
        }

        public static async void ShowEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                // URI
                client.BaseAddress = new Uri("http://localhost:5202/");
                //Request 
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Response = await client.GetAsync("api/Employees/" + id);

                //Response
                if (Response.IsSuccessStatusCode)
                {
                    Employee emp = await Response.Content.ReadAsAsync<Employee>();
                    Console.WriteLine($"Employee Info : id {emp.Id} name {emp.Name} job : {emp.Job} Salary : {emp.Salary:C}");
                }

            }
        }
    }



    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public decimal Salary { get; set; }
    }
}
