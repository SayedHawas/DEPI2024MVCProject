using Microsoft.AspNetCore.Mvc.Filters;

namespace Day6Demo.CustomFilters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
            //
            var controllerName = context.RouteData.Values["Controller"].ToString();
            var actionName = context.RouteData.Values["Action"].ToString();
            Console.WriteLine($"Controller : {controllerName} & Action : {actionName}");

            context.HttpContext.Items["ControllerName"] = controllerName;
            context.HttpContext.Items["ActionName"] = actionName;

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
            //
            var controllerName = context.RouteData.Values["Controller"].ToString();
            var actionName = context.RouteData.Values["Action"].ToString();
            Console.WriteLine($"Controller : {controllerName} & Action : {actionName}");

            context.HttpContext.Items["ControllerName"] = controllerName;
            context.HttpContext.Items["ActionName"] = actionName;
        }
    }
}
