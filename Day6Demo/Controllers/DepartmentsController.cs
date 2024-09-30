using Day6Demo.Models;
using Day6Demo.Repositories.Interfaces;
using Day6Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day6Demo.Controllers
{
    public class DepartmentsController : Controller
    {
        //private readonly Day6MvcdbContext _context;
        private readonly IDepartmentRepository _Repository;
        public DepartmentsController(IDepartmentRepository Repository)  //(Day6MvcdbContext context)
        {
            //_context = context;
            _Repository = Repository;
        }

        [TempData]
        public string Message { get; set; }

        // GET: Departments
        public IActionResult Index()
        {
            //return View(_context.Departments.ToList());
            return View(_Repository.GetAll());
        }

        // GET: Departments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var department = _Repository.GetById(id); //_context.Departments.FirstOrDefault(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            //Validation Server Side 
            if (ModelState.IsValid)
            {
                //_context.Departments.Add(department);
                //_context.SaveChanges();
                _Repository.Create(department);
                Message = $"Department {department.DepartmentName} added ...";
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        //public IActionResult Edit(int? id)
        public IActionResult Edit()
        {
            //HttpContext -->  
            int? id = int.Parse(Request.RouteValues["id"].ToString());
            if (id == null)
            {
                return BadRequest();
            }

            var department = _Repository.GetById(id);  //_context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public IActionResult Edit(int id, Department department)
        public IActionResult Edit(int id)
        {
            var departmentId = int.Parse(Request.Form["DepartmentId"].ToString());
            var departmentName = Request.Form["DepartmentName"].ToString();
            var departmnetManager = Request.Form["DepartmnetManager"].ToString();

            var newDepartment = new Department() { DepartmentId = departmentId, DepartmentName = departmentName, DepartmnetManager = departmnetManager };
            if (id != newDepartment.DepartmentId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Departments.Update(newDepartment);
                    //_context.SaveChanges();
                    _Repository.Update(newDepartment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(newDepartment.DepartmentId))
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
            return View(newDepartment);
        }

        // GET: Departments/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var department = _Repository.GetById(id);  // _context.Departments.FirstOrDefault(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")] //http Selector 
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _Repository.GetById(id); //_context.Departments.Find(id);
            if (department != null)
            {
                //_context.Departments.Remove(department);
                //_context.SaveChanges();
                _Repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
        [NonAction]
        private bool DepartmentExists(int id)
        {
            return _Repository.GetAll().Any(e => e.DepartmentId == id); // _context.Departments.Any(e => e.DepartmentId == id);
        }


        // Show Lists For Department And Employees Cascade List 
        public IActionResult ShowDepartments()
        {
            List<Department> DepartmentList = _Repository.GetAll().ToList();  //_context.Departments.ToList();
            return View(DepartmentList);
        }
        [HttpGet]
        public IActionResult GetDepartment(int pageNumber = 1, int pageSize = 10)
        {
            var totalRecords = _Repository.GetAll().Count();

            var departments = _Repository.GetAll()
                .OrderBy(e => e.DepartmentId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new DepartmentPaginationViewModel
            {
                Departments = departments,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };

            return PartialView("_departmentListPartial", viewModel);
        }

    }
}
