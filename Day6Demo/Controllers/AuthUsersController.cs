using Day6Demo.Models;
using Day6Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Day6Demo.Controllers
{
    public class AuthUsersController : Controller
    {
        private readonly Day6MvcdbContext _dbContext;
        public AuthUsersController(Day6MvcdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Error = "";
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Username == null || loginViewModel.Password == null)
            {
                ViewBag.Error = "Must Enter Username & Password";
                return View("Index");
            }
            var currentUser = _dbContext.Accounts.FirstOrDefault(u => u.Username == loginViewModel.Username && u.Password == loginViewModel.Password);
            if (currentUser == null)
            {
                ViewBag.Error = "Invalid Username & Password";
                return View(nameof(Index));
            }
            TempData["CurrentUser"] = currentUser.Username;
            HttpContext.Session.SetString("User", currentUser.Username);
            return RedirectToAction("Index", "Home");
            //return View(nameof(Index));

        }
    }
}
