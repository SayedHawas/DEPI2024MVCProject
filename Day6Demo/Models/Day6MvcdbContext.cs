using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Day6Demo.ViewModels;

namespace Day6Demo.Models
{

    public partial class Day6MvcdbContext : IdentityDbContext<ApplicationUser>
    {
        public Day6MvcdbContext()
        {
        }

        public Day6MvcdbContext(DbContextOptions<Day6MvcdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Data Source=.\\demos;Initial Catalog=Day6MVCDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Account>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasColumnName("ID");
        //        entity.Property(e => e.Password).HasMaxLength(50);
        //        entity.Property(e => e.Username).HasMaxLength(50);
        //    });

        //    modelBuilder.Entity<Department>(entity =>
        //    {
        //        entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
        //        entity.Property(e => e.DepartmentName).HasMaxLength(50);
        //        entity.Property(e => e.DepartmnetManager).HasMaxLength(50);
        //    });

        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
        //        entity.Property(e => e.Address).HasMaxLength(200);
        //        entity.Property(e => e.Depart_ID).HasColumnName("Depart_ID");
        //        entity.Property(e => e.Email)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //        entity.Property(e => e.EmployeeName).HasMaxLength(50);
        //        entity.Property(e => e.Job).HasMaxLength(50);
        //        entity.Property(e => e.Salary).HasColumnType("decimal(9, 2)");

        //        entity.HasOne(d => d.Depart).WithMany(p => p.Employees)
        //            .HasForeignKey(d => d.Depart_ID)
        //            .HasConstraintName("FK_Employees_Departments");
        //    });
        //    modelBuilder.Entity<Product>(entity =>
        //    {
        //        entity.Property(e => e.Photo).HasMaxLength(255);
        //        entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
        //        entity.Property(e => e.ProductName).HasMaxLength(50);
        //    });


        //    OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Day6Demo.ViewModels.EmployeeViewModel> EmployeeViewModel { get; set; } = default!;

public DbSet<Day6Demo.ViewModels.RegistryUserViewModel> RegistryUserViewModel { get; set; } = default!;

public DbSet<Day6Demo.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
    }
}