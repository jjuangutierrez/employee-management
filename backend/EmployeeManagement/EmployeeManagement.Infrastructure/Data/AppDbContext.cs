using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Convert enums to string
        modelBuilder.Entity<Employee>()
            .Property(e => e.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Employee>()
            .Property(e => e.State)
            .HasConversion<string>();

        modelBuilder.Entity<Employee>()
            .Property(e => e.DocumentType)
            .HasConversion<string>();
    }
}
