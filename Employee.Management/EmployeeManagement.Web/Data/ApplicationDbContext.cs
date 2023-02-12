using EmployeeManagementWeb.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EmployeeManagementWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                .HasColumnType("int");
            });
        }
    }
}