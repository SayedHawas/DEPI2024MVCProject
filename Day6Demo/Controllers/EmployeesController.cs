using Day6Demo.Models;
using Day6Demo.Repositories.Interfaces;
using Day6Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day6Demo.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly Day6MvcdbContext _context;
        private readonly IEmployeeRepository _repository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeesController(IEmployeeRepository repository, IDepartmentRepository departmentRepository)
        {
            //_context = context;
            _repository = repository;
            _departmentRepository = departmentRepository;
        }
        // GET: Employees
        [ResponseCache(Duration = 100)]
        public IActionResult Index()
        {
            //var day6MvcdbContext = _context.Employees.Include(e => e.Depart);
            //return View(day6MvcdbContext.ToList());
            return View(_repository.GetAllWithDepartment().ToList());
        }
        public IActionResult EmployeeWebsite()
        {
            //var day6MvcdbContext = _context.Employees.Include(e => e.Depart);
            //return View(day6MvcdbContext.ToList());
            return View(_repository.GetAllWithDepartment().ToList());
        }
        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _repository.GetByIdWithDepartment(id); //_context.Employees.Include(e => e.Depart).FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // GET: Employees/Create
        public IActionResult Create()
        {
            //ViewData["Depart_ID"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["Depart_ID"] = new SelectList(_departmentRepository.GetAll(), "DepartmentId", "DepartmentName");
            return View();
        }
        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([ModelBinder(typeof(EmployeeBinder))] Employee employee)
        {

            if (ModelState.IsValid)
            {
                //_context.Employees.Add(employee);
                //_context.SaveChanges();
                _repository.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Depart_ID"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", employee.Depart_ID);
            ViewData["Depart_ID"] = new SelectList(_departmentRepository.GetAll(), "DepartmentId", "DepartmentName", employee.Depart_ID);
            return View(employee);
        }
        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _repository.GetById(id);//_context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            //ViewData["Depart_ID"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", employee.Depart_ID);
            ViewData["Depart_ID"] = new SelectList(_departmentRepository.GetAll(), "DepartmentId", "DepartmentName", employee.Depart_ID);
            return View(employee);
        }
        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Employees.Update(employee);
                    //_context.SaveChanges();
                    _repository.Update(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Depart_ID"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", employee.Depart_ID);
            ViewData["Depart_ID"] = new SelectList(_departmentRepository.GetAll(), "DepartmentId", "DepartmentName", employee.Depart_ID);
            return View(employee);
        }
        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _repository.GetById(id);  // _context.Employees.Include(e => e.Depart).FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _repository.GetById(id);//_context.Employees.Find(id);
            if (employee != null)
            {
                //_context.Employees.Remove(employee);
                //_context.SaveChanges();
                _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool EmployeeExists(int id)
        {
            //return _context.Employees.Any(e => e.EmployeeId == id);
            return _repository.GetAll().Any(e => e.EmployeeId == id);
        }
        public IActionResult ShowEmployee(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _repository.GetByIdWithDepartment(id);  //_context.Employees.Include(e => e.Depart).FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.EmployeeName,
                Job = employee.Job,
                department = employee.Depart.DepartmentName,
                Manager = employee.Depart.DepartmnetManager
            };
            return View(viewModel);
        }
        //Employees/ShowEmployeeDetails/3
        public IActionResult ShowEmployeeDetails(int? id)
        {
            //var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            // var emp = _context.Employees.Include(d => d.Depart).FirstOrDefault(e => e.EmployeeId == id);
            var emp = _repository.GetByIdWithDepartment(id);
            return PartialView("ShowEmployeeDetails", emp);
        }
        //Departments/ShowEmployees?departmentId=
        public IActionResult ShowEmployees(int departmentId)
        {
            //List<Employee> EmployeeList = _context.Employees.Where(e => e.Depart_ID == departmentId).ToList();
            List<Employee> EmployeeList = _repository.GetEmployeesByDepartment(departmentId).ToList();
            return Json(EmployeeList);
        }
    }
}
