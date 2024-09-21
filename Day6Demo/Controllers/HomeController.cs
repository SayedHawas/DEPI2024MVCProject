using Day6Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Day6Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Day6MvcdbContext _day6MVCdbContext;
        public HomeController(ILogger<HomeController> logger, Day6MvcdbContext day6MVCdbContext)
        {
            _logger = logger;
            _day6MVCdbContext = day6MVCdbContext;
        }

        public IActionResult ShowList()
        {
            //List From DB 
            //var deprtmentList = _day6MVCdbContext.Departments.ToList();
            ViewBag.DepartmentId = new SelectList(_day6MVCdbContext.Departments, "DepartmentId", "DepartmentName");

            return View();

            //ViewBag.DepartmentId = new SelectList(_day6MVCdbContext.Departments, "DepartmentId", "DepartmentName" , 3);  //with select Number 3 
            //Pass to View 
            //View Data  ---> Dic Object <Key , value > <string , object> Casting 
            //View Bag   ---> Dynamic Not Need to Casting  
            //Model (Loosly Type m Strongly type )  @model 
        }
        public IActionResult Index()
        {
            var cookie = Request.Cookies["AppName"];
            ViewBag.MyCookie = cookie;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ShowWebSite()
        {
            return View();
        }
    }
}
