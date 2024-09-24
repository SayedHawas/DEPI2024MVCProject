using Day6Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Day6Demo.Controllers
{
    public class DemosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Temp Data
        public IActionResult SetTempData()
        {
            //Declare TempData 

            if (!TempData.ContainsKey("Name"))
                TempData.Add("Name", "Smart Software");


            if (!TempData.ContainsKey("Age"))
                TempData["Age"] = 40; //Set 

            return Content("Save TempData ....");
        }
        public IActionResult GetTempData()
        {
            //Normal read For Temp Data 
            string name = "No Data";
            int age = 0;
            if (TempData.ContainsKey("Name"))
            {
                //name = TempData["Name"].ToString();
                name = TempData.Peek("Name").ToString();
            }
            if (TempData.ContainsKey("Age"))
            {
                //age = (int)TempData["Age"];
                age = (int)TempData.Peek("Age");
            }
            return Content($"TempData :  name {name} age  {age} ...");

        }
        public IActionResult GetTempDataSecond()
        {
            //Normal read For Temp Data 
            string name = "No Data";
            int age = 0;
            if (TempData.ContainsKey("Name"))
            {

                name = TempData["Name"].ToString();
                TempData.Keep("Name");
            }
            if (TempData.ContainsKey("Age"))
            {
                age = (int)TempData["Age"];
                TempData.Keep("Age");
            }
            //TempData.Keep();
            return Content($"TempData Second Call :  name {name} age  {age} ...");

        }
        public IActionResult GetTempDataThree()
        {
            //Normal read For Temp Data 
            string name = "No Data";
            int age = 0;
            if (TempData.ContainsKey("Name"))
            {

                name = TempData["Name"].ToString();
            }
            if (TempData.ContainsKey("Age"))
            {
                age = (int)TempData["Age"];
            }
            return Content($"TempData Second Call :  name {name} age  {age} ...");

        }

        //Cookies 
        public IActionResult SetCookiesData()
        {
            CookieOptions cookiesOptions = new CookieOptions();
            cookiesOptions.Expires = DateTime.Now.AddDays(15);
            //Declare Cookies 
            Response.Cookies.Append("AppName", "Smart software", cookiesOptions);   // After 15 Days
            Response.Cookies.Append("Number", "120");//Session Cookies 20 Min

            return Content("Cookies Saving ....");

        }
        public IActionResult GetCookiesData()
        {
            string appName = Request.Cookies["AppName"];
            int Number = int.Parse(Request.Cookies["Number"]);

            return Content($"Cookies:{appName} & {Number}");
        }
        public IActionResult CleanCookiesData()
        {
            CookieOptions cookiesOptions = new CookieOptions();
            cookiesOptions.Expires = DateTime.Now.AddDays(-1);
            //Declare Cookies 
            Response.Cookies.Append("AppName", "Smart software", cookiesOptions);  //Clean

            return Content("Cookies Clean ....");
        }

        //Session 
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "Sayed Hawas");
            HttpContext.Session.SetInt32("Counter", 100);
            return Content("Save Session ");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("name");
            int? counter = HttpContext.Session.GetInt32("Counter");
            return Content($"Name {name} & Counter {counter}  ");
        }

        //Binding 
        //Demos/BindingPrimitive?id=5&name=Ahmed&Courses[1]=SQL&Courses[0]=MVCCore
        public IActionResult BindingPrimitive(int id, string Name, string[] Courses)
        {
            StringBuilder sb = new StringBuilder();
            if (Courses.Length > 0)
            {
                for (int i = 0; i < Courses.Length; i++)
                {
                    sb.Append($"Data:{id} {Name} {Courses[i]} \n");
                }
            }
            return Content($"{sb.ToString()}");
        }

        //Binding Collection
        //Demos/BindingCollection?id=6&name=Ahmed&Mark[1]=80&Mark[2]=90
        public IActionResult BindingCollection(int id, string Name, Dictionary<int, int> Mark)
        {
            StringBuilder sb = new StringBuilder();
            if (Mark.Count > 0)
            {
                for (int i = 0; i < Mark.Count; i++)
                {
                    int value = 0;
                    Mark.TryGetValue(i, out value);
                    sb.Append($"Data:{id} {Name} {value}  \n");
                }
            }
            return Content($"{sb.ToString()}");
        }

        //Demos/BindingComplex?departmentId=8&departmentName=HR&departmnetManager=AhmedAli&Employees[0].EmployeeName=AmrAhmed
        public IActionResult BindingComplex(int departmentId, string departmentName, string departmnetManager, Department department)
        {
            return Content($"id {department.DepartmentId} Name {department.DepartmentName} Manager: {department.DepartmnetManager} ");
        }

        //Demos/BindingComplexTwo?departmentId=8&departmentName=HR&departmnetManager=AhmedAli&Employees[0].EmployeeName=AmrAhmed
        public IActionResult BindingComplexTwo([Bind(include: "DepartmentId,DepartmentName")] Department department)
        {
            return Content($"id {department.DepartmentId} Name {department.DepartmentName} Manager: {department.DepartmnetManager} ");
        }

        //Action for test 
        public IActionResult TestAction()
        {
            ViewData["Title"] = "Welcome in Test With MVC ";
            return View();
        }
        public int divi(int x, int y)
        {
            return x / y;
        }


    }
}
