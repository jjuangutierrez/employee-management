using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IUserRepository : IDisposable
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId);
    Task<User?> GetUserAsync(int id);
    Task<User> InsertUserAsync(User user);
    Task DeleteUserAsync(int userId);
    Task<User> UpdateUserAsync(User user);
}
