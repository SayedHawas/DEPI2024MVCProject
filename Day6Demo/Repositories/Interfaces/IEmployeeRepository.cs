using Day6Demo.Models;

namespace Day6Demo.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAllWithDepartment();

        Employee GetByIdWithDepartment(int? id);

        IEnumerable<Employee> GetEmployeesByDepartment(int departmentID);

    }
}
