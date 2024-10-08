﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Day6Demo.Models
{
    public class EmployeeBinder : IModelBinder
    {
        //Custom Model Binder
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var employeeName = bindingContext.HttpContext.Request.Form["EmployeeName"];
            var job = bindingContext.HttpContext.Request.Form["Job"];
            var salary = bindingContext.HttpContext.Request.Form["Salary"];
            var address = bindingContext.HttpContext.Request.Form["Address"];
            var email = bindingContext.HttpContext.Request.Form["Email"];
            var Depart_ID = bindingContext.HttpContext.Request.Form["Depart_ID"];

            // Validate and convert salary
            if (!decimal.TryParse(salary, out decimal salaryDecimal))
            {
                bindingContext.ModelState.AddModelError("Salary", "Invalid salary format.");
                //bindingContext.Result = ModelBindingResult.Failed();
                //return;
            }
            if (int.Parse(Depart_ID) == 0)
            {
                bindingContext.ModelState.AddModelError("Depart_ID", "Must Select the Department");
            }
            //create New Salary 
            decimal newSalary = Convert.ToDecimal(salary) + (Convert.ToDecimal(salary) * .1m);

            //Now create Object From Employee 
            Employee employee = new Employee
            {
                EmployeeName = employeeName,
                Job = job,
                Salary = newSalary,
                Address = address,
                Email = email,
                Depart_ID = int.Parse(Depart_ID)
            };
            // Set the result as successful and pass the employee object
            bindingContext.Result = ModelBindingResult.Success(employee);
        }
    }
}
