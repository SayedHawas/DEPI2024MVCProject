using Day6Demo.Models;

namespace Day6Demo.Repositories.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Guid lifetime { get; set; }
    }
}
