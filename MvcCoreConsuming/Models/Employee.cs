using System.ComponentModel.DataAnnotations;

namespace MvcCoreConsuming.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Job { get; set; }

        [Required]
        [DataType("decimal(9,2)")]
        [RegularExpression(@"^\d+.?\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal Salary { get; set; }
    }
}
