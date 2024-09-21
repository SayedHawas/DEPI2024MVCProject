using System.ComponentModel.DataAnnotations;

namespace Day6Demo.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; } = null!;

        public string Job { get; set; } = null!;

        public string department { get; set; }

        public string Manager { get; set; }
    }
}
