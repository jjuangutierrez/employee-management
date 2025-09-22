using EmployeeManagement.Domain.Entities;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId);
    Task<User?> GetUserByIdAsync(int id);
    Task<User> InsertUserAsync(User user);
    Task DeleteUserAsync(int userId);
    Task<User> UpdateUserAsync(User user);
}
