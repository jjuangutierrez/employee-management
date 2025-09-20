using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId);
    Task<User?> GetUserAsync(int userId);
    Task<User> InsertUserAsync(User user);
    Task<User> DeleteUserAsync(int userId);
    Task<User> UpdateUserAsync(User user, WorkInfo workInfo);
}

