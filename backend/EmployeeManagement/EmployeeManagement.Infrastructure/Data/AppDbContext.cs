using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<WorkInfo> WorkInfos { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<Announcement> Announcements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);




        // user is only one department
        modelBuilder.Entity<User>()
            .HasOne(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // depaprment just have one manager
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Manager)
            .WithMany(u => u.ManagedDepartments)
            .HasForeignKey(d => d.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Announcement
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasOne(a => a.User)
                  .WithMany()
                  .HasForeignKey(a => a.CreatedBy)
                  .OnDelete(DeleteBehavior.Restrict);
        });


        // Convert enums to string
        modelBuilder.Entity<User>()
            .Property(e => e.Role)
            .HasConversion<string>();

        modelBuilder.Entity<WorkInfo>()
            .Property(e => e.State)
            .HasConversion<string>();

        modelBuilder.Entity<WorkInfo>()
            .Property(e => e.DocumentType)
            .HasConversion<string>();

        modelBuilder.Entity<TaskEntity>()
            .Property(e => e.Status)
            .HasConversion<string>();
    }
}
