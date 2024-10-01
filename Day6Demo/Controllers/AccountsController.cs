using Day6Demo.Models;
using Day6Demo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day6Demo.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registry()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registry(RegistryUserViewModel registryUserViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping 
                ApplicationUser currentuser = new ApplicationUser();
                currentuser.UserName = registryUserViewModel.UserName;
                currentuser.Email = registryUserViewModel.Email;
                currentuser.PasswordHash = registryUserViewModel.Password;
                currentuser.City = registryUserViewModel.City;

                IdentityResult result = await _userManager.CreateAsync(currentuser, registryUserViewModel.Password);
                if (result.Succeeded)
                {
                    //cookies
                    //Create Cookies
                    await _signInManager.SignInAsync(currentuser, false);

                    //List<Claim> claims = new List<Claim>();
                    //claims.Add(new Claim("job", "Eng"));
                    //await _signInManager.SignInWithClaimsAsync(currentuser, false, claims);

                    RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, erroritem.Description);
                    }
                }
            }
            return View(registryUserViewModel);
        }


        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginUserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.FindByNameAsync(loginUserViewModel.Username);

                if (currentUser != null)
                {
                    bool userfound = await _userManager.CheckPasswordAsync(currentUser, loginUserViewModel.Password);
                    if (userfound)
                    {
                        await _signInManager.SignInAsync(currentUser, loginUserViewModel.RememberMe);
                        RedirectToAction("Index", "Employees");
                    }
                }
                ModelState.AddModelError("Password", "User Name Or Password Invalid ....");
            }
            return View(loginUserViewModel);
        }

    }
}
