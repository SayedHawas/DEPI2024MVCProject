using Day6Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day6Demo.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly Day6MvcdbContext _context;

        public DepartmentsController(Day6MvcdbContext context)
        {
            _context = context;
        }

        [TempData]
        public string Message { get; set; }

        // GET: Departments
        public IActionResult Index()
        {
            return View(_context.Departments.ToList());
        }

        // GET: Departments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var department = _context.Departments.FirstOrDefault(m => m.DepartmentId == id);
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
                _context.Departments.Add(department);
                _context.SaveChanges();
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

            var department = _context.Departments.Find(id);
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
                    _context.Departments.Update(newDepartment);
                    _context.SaveChanges();
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

            var department = _context.Departments.FirstOrDefault(m => m.DepartmentId == id);
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
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [NonAction]
        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
