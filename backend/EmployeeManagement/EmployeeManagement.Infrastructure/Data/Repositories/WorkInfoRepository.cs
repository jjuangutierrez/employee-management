using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data.Repositories;

public class WorkInfoRepository : IWorkInfoRepository, IDisposable
{
    private readonly AppDbContext _context;

    public WorkInfoRepository(AppDbContext context) => _context = context;

    public async Task DeleteWorkInfoAsync(int workInfoId)
    {
        var workInfo = await _context.WorkInfos.FindAsync(workInfoId);
        var user = await _context.Users.FindAsync(workInfoId);

        if (workInfo != null || user != null)
        {
            _context.WorkInfos.Remove(workInfo);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<WorkInfo>> GetAllWorkInfosAsync()
    {
        return await _context.WorkInfos.ToListAsync(); 
    }

    public async Task<WorkInfo?> GetWorkInfoAsync(int id)
    {
        return await _context.WorkInfos.FindAsync(id);
    }

    public async Task<WorkInfo> InsertWorkInfoAsync(WorkInfo workInfo)
    {
        await _context.WorkInfos.AddAsync(workInfo);
        await _context.SaveChangesAsync();

        return workInfo;
    }

    public async Task UpdateWorkInfoAsync(WorkInfo workInfo)
    {
        var existingEmployee = await _context.WorkInfos.FindAsync(workInfo.Id);
        if (existingEmployee == null)
            throw new KeyNotFoundException("Employee not found");

        // Update
        existingEmployee.Age = workInfo.Age;
        existingEmployee.DocumentNumber = workInfo.DocumentNumber;
        existingEmployee.DocumentType = workInfo.DocumentType;
        existingEmployee.HireDate = workInfo.HireDate;
        existingEmployee.Phone = workInfo.Phone;
        existingEmployee.AlternatePhone = workInfo.AlternatePhone;
        existingEmployee.Salary = workInfo.Salary;
        existingEmployee.Position = workInfo.Position;
        existingEmployee.UpdateAt = DateTime.UtcNow;

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
