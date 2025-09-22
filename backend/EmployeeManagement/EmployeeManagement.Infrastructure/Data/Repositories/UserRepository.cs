using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _context.Users
            .Include(u => u.WorkInfo)
            .Include(u => u.Department)
            .ToListAsync();

    public async Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId) => await _context.Users
            .Include(u => u.WorkInfo)
            .Include(u => u.Department)
            .Where(u => u.DepartmentId == departmentId)
            .ToListAsync();

    public async Task<User?> GetUserByIdAsync(int id) => await _context.Users
            .Include(u => u.WorkInfo)
            .Include(u => u.Department)
            .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User> InsertUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return await GetUserByIdAsync(user.Id) ?? user;
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return await GetUserByIdAsync(user.Id)?? user;
    }
}