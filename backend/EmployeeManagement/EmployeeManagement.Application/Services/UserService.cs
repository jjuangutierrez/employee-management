using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IWorkInfoRepository _workInfoRepository;

    public UserService(IUserRepository userRepository, IWorkInfoRepository workInfoRepository)
    {
        _userRepository = userRepository;
        _workInfoRepository = workInfoRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<IEnumerable<User>> GetUsersByDepartmentAsync(int departmentId)
    {
        var users = await _userRepository.GetUsersByDepartmentAsync(departmentId);
        if (users == null || !users.Any())
            throw new KeyNotFoundException($"No users found for department {departmentId}");
        return users;
    }

    public async Task<User> GetUserAsync(int userId)
    {
        var user = await _userRepository.GetUserAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"User for UserID: {userId} not found");

        return user;
    }

    public async Task<User> InsertUserAsync(User user)
    {
        if (user.WorkInfo == null)
            throw new ArgumentException("WorkInfo is required when creating a user");

        var workInfo = user.WorkInfo;
        user.WorkInfo = null;

        var createdUser = await _userRepository.InsertUserAsync(user);

        workInfo.UserId = createdUser.Id;
        var createdWorkInfo = await _workInfoRepository.InsertWorkInfoAsync(workInfo);

        return await _userRepository.GetUserAsync(createdUser.Id) ?? createdUser;
    }

    public async Task<User> DeleteUserAsync(int userId)
    {
        var existingUser = await _userRepository.GetUserAsync(userId);
        if (existingUser == null)
            throw new KeyNotFoundException("User not found");

        await _userRepository.DeleteUserAsync(userId);
        return existingUser;
    }

    public async Task<User> UpdateUserAsync(User user, WorkInfo workInfo)
    {
        var updatedUser = await _userRepository.UpdateUserAsync(user);

        if (workInfo != null)
        {
            workInfo.UserId = user.Id;
            await _workInfoRepository.UpdateWorkInfoAsync(workInfo);
        }

        return await _userRepository.GetUserAsync(user.Id) ?? updatedUser;
    }
}