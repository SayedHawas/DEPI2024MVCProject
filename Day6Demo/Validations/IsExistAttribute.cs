using Day6Demo.Models;
using System.ComponentModel.DataAnnotations;

namespace Day6Demo.Validations
{
    public class IsExistAttribute : ValidationAttribute
    {
        public string MyErrorMessage { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Create Instance Entity
            var _context = (Day6MvcdbContext)validationContext.GetService(typeof(Day6MvcdbContext));

            //Get Data 
            string data = value.ToString();
            //Check 
            Employee currentName = _context.Employees.FirstOrDefault(e => e.EmployeeName == data);
            if (currentName != null)
            {
                return new ValidationResult(MyErrorMessage);

            }
            return ValidationResult.Success;

        }
    }
}
