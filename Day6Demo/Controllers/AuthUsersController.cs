using Microsoft.AspNetCore.Mvc;

namespace Day6Demo.Controllers
{
    public class AuthUsersController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Error = "";
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            if (username == null || password == null)
            {
                ViewBag.Error = "Must Enter Username & Password";
                return View("Index");
            }
            if (username == "ahmed" && password == "1234")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid Username & Password";
                return View(nameof(Index));
            }

        }
    }
}
