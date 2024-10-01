using Microsoft.AspNetCore.Mvc.Filters;

namespace Day6Demo.CustomFilters
{
    public class CustomExecptionfilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
