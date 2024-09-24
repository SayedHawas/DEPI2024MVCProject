using System.ComponentModel.DataAnnotations;

namespace Day6Demo.Validations
{
    public class SalaryAttribute
    {
        public static ValidationResult ValidateSalary(decimal salary, ValidationContext context)
        {
            if (salary < 5000)
                return new ValidationResult("Salary Employee must be at least 5000.");
            return ValidationResult.Success;
        }
    }
}
