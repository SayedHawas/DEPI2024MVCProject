using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;

namespace WebApiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=.\\demo; initial Catalog=WebApiCoreDb;Integrated Security =True;Trust Server Certificate = True");
        }
    }
}
