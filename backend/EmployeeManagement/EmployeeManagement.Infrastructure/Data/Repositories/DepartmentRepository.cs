using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository, IDisposable
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _context.Departaments.ToListAsync();
    }

    public async Task<Department?> GetDepartmentAsync(int id)
    {
        return await _context.Departaments.FindAsync(id);
    }

    public async Task InsertDepartmentAsync(Department department)
    {
        await _context.Departaments.AddAsync(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDepartmentAsync(Department department)
    {
        _context.Entry(department).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDepartmentAsync(int departmentId)
    {
        var department = await _context.Departaments.FindAsync(departmentId);
        if (department != null)
        {
            _context.Departaments.Remove(department);
            await _context.SaveChangesAsync();
        }
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
