using Day6Demo.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day6Demo.Models
{
    [ModelMetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {

    }

    public class EmployeeMetaData
    {
        //Add Validation 
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Please Enter Your Name ")]
        [MaxLength(50, ErrorMessage = "Must Enter Name Less than 50 letters")]
        [IsExist(MyErrorMessage = "Name is Already Exist")]
        public string EmployeeName { get; set; } = null!;

        public string Job { get; set; } = null!;
        [Required(ErrorMessage = "Please Enter Your Salary")]
        [CustomValidation(typeof(SalaryAttribute), "ValidateSalary")]
        public decimal Salary { get; set; }

        public string? Address { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        //[ForeignKey(nameof(Depart))] //
        [ForeignKey("Depart")]
        public int? DepartId { get; set; }
    }
}
