using Microsoft.AspNetCore.Mvc;
using MvcCoreConsuming.Models;
using System.Net.Http.Headers;
namespace MvcCoreConsuming.Controllers
{
    public class EmployeesController : Controller
    {

        /*
        1-Create object from Client 
        2-Get URL  Add BaseAddress By New URI ("URL")
        3-Set Result is XML OR JSON from DefaultrequestHeader .accept .addMediatypeFormatter
        4- Create Get Data  By GetAsync   As result 
        */
        private string BaseURI = "http://localhost:5202/";
        HttpClient client;
        public IActionResult Index()
        {

            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                HttpResponseMessage response = client.GetAsync("api/Employees").Result;
                var employees = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return View(employees);
            }

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {

                using (client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURI);
                    HttpResponseMessage response = client.PostAsJsonAsync("api/Employees", newEmployee).Result;
                    return RedirectToAction("Index");
                }
            }
            return View(newEmployee);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                HttpResponseMessage response = client.GetAsync("api/Employees/" + id).Result;
                var employee = response.Content.ReadAsAsync<Employee>().Result;
                return View(employee);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                HttpResponseMessage response = client.GetAsync("api/Employees/" + id).Result;
                var employee = response.Content.ReadAsAsync<Employee>().Result;
                return View(employee);
            }
        }
        [HttpPost]
        public IActionResult Edit(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {

                client = new HttpClient();
                client.BaseAddress = new Uri(BaseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("api/Employees?id=" + newEmployee.Id, newEmployee).Result;
                return RedirectToAction("Index");
            }
            return View(newEmployee);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                HttpResponseMessage response = client.GetAsync("api/Employees/" + id).Result;
                var employee = response.Content.ReadAsAsync<Employee>().Result;
                return View(employee);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                HttpResponseMessage response = client.DeleteAsync("api/Employees?id=" + id).Result;
                return RedirectToAction("Index");
            }
        }
    }
}
