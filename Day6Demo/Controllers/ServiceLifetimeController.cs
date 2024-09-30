using Day6Demo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Day6Demo.Controllers
{
    public class ServiceLifetimeController : Controller
    {
        //1- Registry = Add Service (IDepartmentRepository , DepartmentRepository)
        //2- Request Resolving Object DI
        //3- Lifetime Add scoped 
        private readonly IDepartmentRepository _departmentRepository;

        public ServiceLifetimeController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        //ServiceLifetime/index
        public IActionResult Index()
        {
            ViewBag.life = _departmentRepository.lifetime;
            return View();
        }
    }
}
