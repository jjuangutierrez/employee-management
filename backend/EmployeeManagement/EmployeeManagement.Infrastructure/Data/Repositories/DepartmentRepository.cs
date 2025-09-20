using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository, IDisposable
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context) => _context = context;

    public async Task DeleteDepartmentAsync(int departmentId)
    {
        var department = await _context.Departments.FindAsync(departmentId);
        if (department == null)
            throw new Exception("Department not found!");

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _context.Departments
            .Include(d => d.Manager)
                .ThenInclude(m => m.WorkInfo)
            .Include(d => d.Users)
                .ThenInclude(u => u.WorkInfo)
            .ToListAsync();
    }

    public async Task<Department> GetDepartmentAsync(int id)
    {
        var department = await _context.Departments
            .Include(d => d.Manager)
                .ThenInclude(m => m.WorkInfo)
            .Include(d => d.Users)
                .ThenInclude(u => u.WorkInfo) 
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department == null)
            throw new Exception("Department not found!");

        return department;
    }

    public async Task<Department> InsertDepartmentAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();

        return await GetDepartmentAsync(department.Id);
    }

    public async Task UpdateDepartmentAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}