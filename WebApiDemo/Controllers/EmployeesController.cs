using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        //CRUD
        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> employeeList = _context.Employees.ToList();
            return Ok(employeeList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByname(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var employee = _context.Employees.FirstOrDefault(e => e.Name.Contains(name));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] Employee newEmployee)//[FromForm] 
        {
            //Check state
            if (ModelState.IsValid)
            {
                //Save 
                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
                //return 
                //return Created();
                return CreatedAtAction("GetByID", new { id = newEmployee.Id }, newEmployee);
            }
            return BadRequest(ModelState);
            //return With Error 

        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Employee newEmployee)
        {
            if (id == null || id != newEmployee.Id)
            {
                return BadRequest();
            }
            if (!EmployeeExists(id))
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(newEmployee).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(newEmployee);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
