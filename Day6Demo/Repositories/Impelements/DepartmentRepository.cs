using Day6Demo.Models;
using Day6Demo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day6Demo.Repositories.Impelements
{
    public class DepartmentRepository : IDepartmentRepository
    {

        public Guid lifetime { get; set; }

        //Object DbContext
        private readonly Day6MvcdbContext _context;
        public DepartmentRepository(Day6MvcdbContext context)
        {
            lifetime = Guid.NewGuid();
            _context = context;
        }
        public void Create(Department entity)
        {
            _context.Departments.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(int? id)
        {
            var department = GetById(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public Department GetById(int? id)
        {
            return _context.Departments.FirstOrDefault(m => m.DepartmentId == id);
        }
        public void Update(Department entity)
        {
            _context.Departments.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
