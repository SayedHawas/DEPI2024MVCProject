using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;

namespace WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
               options.AddPolicy("MyCors", CorsPolicyBuilder =>
               {
                   CorsPolicyBuilder.AllowAnyOrigin();
                   // CorsPolicyBuilder.AllowAnyHeader();
               }
            ));

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseAuthorization();


            app.UseCors("MyCors"); //Add Cors
            app.MapControllers();

            app.Run();
        }
    }
}
