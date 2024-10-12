using Day6Demo.Models;
using Day6Demo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day6Demo.Repositories.Impelements
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Day6MvcdbContext _context;
        public EmployeeRepository(Day6MvcdbContext context)
        {
            _context = context;
        }
        public void Create(Employee entity)
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(int? id)
        {
            var employee = GetById(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        public void Update(Employee entity)
        {
            _context.Employees.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }
        public IEnumerable<Employee> GetAllWithDepartment()
        {
            return _context.Employees.Include(d => d.Depart);
        }
        public Employee GetById(int? id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }
        public Employee GetByIdWithDepartment(int? id)
        {
            return _context.Employees.Include(d => d.Depart).FirstOrDefault(e => e.EmployeeId == id);
        }

        public IEnumerable<Employee> GetEmployeesByDepartment(int departmentID)
        {
            return _context.Employees.Where(e => e.Depart_ID == departmentID);
        }
    }
}
