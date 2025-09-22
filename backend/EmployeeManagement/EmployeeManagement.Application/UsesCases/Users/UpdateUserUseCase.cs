using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Application.Interfaces;

public class UpdateUserUseCase
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher _hasher;

    public UpdateUserUseCase(IUserService userService, IPasswordHasher hasher)
    {
        _userService = userService;
        _hasher = hasher;
    }

    public async Task<ResponseUserDto?> ExecuteAsync(int id, UpdateUserDto dto)
    {
        var existingUser = await _userService.GetUserByIdAsync(id);
        if (existingUser == null) return null;

        existingUser.FirstName = dto.FirstName ?? existingUser.FirstName;
        existingUser.LastName = dto.LastName ?? existingUser.LastName;
        existingUser.Email = dto.Email ?? existingUser.Email;
        existingUser.Role = dto.Role ?? existingUser.Role;
        existingUser.Salary = dto.Salary ?? existingUser.Salary;
        existingUser.Position = dto.Position ?? existingUser.Position;
        existingUser.UpdatedAt = DateTime.UtcNow;

        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            existingUser.Password = _hasher.Hash(dto.Password);
        }

        if (dto.WorkInfo != null && existingUser.WorkInfo != null)
        {
            existingUser.WorkInfo.HireDate = dto.WorkInfo.HireDate ?? existingUser.WorkInfo.HireDate;
            existingUser.WorkInfo.State = dto.WorkInfo.State ?? existingUser.WorkInfo.State;
            existingUser.WorkInfo.UpdatedAt = DateTime.UtcNow;
        }

        var updatedUser = await _userService.UpdateUserAsync(existingUser, existingUser.WorkInfo);

        return new ResponseUserDto
        {
            Id = updatedUser.Id,
            FirstName = updatedUser.FirstName,
            LastName = updatedUser.LastName,
            Email = updatedUser.Email,
            Role = updatedUser.Role,
            Salary = updatedUser.Salary,
            Position = updatedUser.Position,
            DepartmentId = updatedUser.DepartmentId,
            CreatedAt = updatedUser.CreatedAt,
            UpdatedAt = updatedUser.UpdatedAt
        };
    }
}
