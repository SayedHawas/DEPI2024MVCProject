using Day6Demo.Models;
using Day6Demo.Repositories.Impelements;
using Day6Demo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day6Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
            builder.Services.AddControllersWithViews();//.AddSessionStateTempDataProvider();
            builder.Services.AddSession(config =>
            {
                config.IdleTimeout = TimeSpan.FromMinutes(20);
            });
            //Custom Services
            //
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            //Container DB SQL server 
            builder.Services.AddDbContext<Day6MvcdbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });


            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            //app.MapControllerRoute(
            //  name: "Route1",
            //  pattern: "demo/{id:range(10,50):int}/{name:alpha?}",
            //  new
            //  {
            //      controller = "Demos",
            //      action = "DemoRouting"
            //  });

            //app.MapControllerRoute(
            //    name: "Route2",
            //    pattern: "{controller=Products}/{action=Index}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=ShowWebSite}/{id:int?}");


            #region Custom Middle-Ware
            //app.Use(async (HttpContext, next) =>
            //{
            //    //Execute 
            //    await HttpContext.Response.WriteAsync("1-Write from MiddleWare  \n");
            //    //Call the Next Middleware
            //    await next.Invoke();
            //    //When Go Back to client
            //    await HttpContext.Response.WriteAsync("5-Write from MiddleWare  \n");
            //});

            //app.Use(async (HttpContext, next) =>
            //{
            //    //Execute 
            //    await HttpContext.Response.WriteAsync("2-Write from MiddleWare  \n");
            //    //Call the Next Middleware
            //    await next.Invoke();
            //    //When Go Back to client
            //    await HttpContext.Response.WriteAsync("4-Write from MiddleWare  \n");
            //});

            //app.Run(async (HttpContext) =>
            //{
            //    //Execute 
            //    await HttpContext.Response.WriteAsync("3-Write from MiddleWare Terminator  \n");

            //});
            #endregion

            app.Run();
        }
    }
}
