using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId);
    Task<User> GetUserByIdAsync(int userId);
    Task<User> InsertUserAsync(User user, WorkInfo workInfo);
    Task<User> DeleteUserAsync(int userId);
    Task<User> UpdateUserAsync(User user, WorkInfo workInfo);
}

