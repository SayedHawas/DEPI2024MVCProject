using Day6Demo.Models;
namespace Day6Demo.ViewModels
{
    public class DepartmentPaginationViewModel
    {
        public List<Department> Departments { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}
