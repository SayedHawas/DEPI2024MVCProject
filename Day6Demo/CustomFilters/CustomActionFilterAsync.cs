using Microsoft.AspNetCore.Mvc.Filters;

namespace Day6Demo.CustomFilters
{
    public class CustomActionFilterAsync : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //throw new NotImplementedException();

            await next();
        }
    }
}
