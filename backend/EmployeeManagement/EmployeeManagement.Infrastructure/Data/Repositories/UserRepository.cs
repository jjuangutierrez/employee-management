using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository, IDisposable
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.WorkInfo)
            .Include(u => u.Department)
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId)
    {
        return await _context.Users
            .Include(u => u.WorkInfo)
            .Include(u => u.Department)
            .Where(u => u.DepartmentId == departmentId)
            .ToListAsync();
    }

    public async Task<User?> GetUserAsync(int userId)
    {
        return await _context.Users
            .Include(u => u.WorkInfo)
            .Include(u => u.Department)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await GetUserAsync(id);
    }

    public async Task<User> InsertUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return await GetUserAsync(user.Id) ?? user;
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users
            .Include(u => u.WorkInfo)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser == null)
            throw new KeyNotFoundException("User not found");

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Role = user.Role;
        existingUser.DepartmentId = user.DepartmentId;
        existingUser.UpdateAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return await GetUserAsync(existingUser.Id) ?? existingUser;
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