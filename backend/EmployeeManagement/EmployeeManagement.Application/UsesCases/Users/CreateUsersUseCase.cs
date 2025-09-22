using AutoMapper;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.UseCases.Users;

public class CreateUsersUseCase
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher _hasher;

    public CreateUsersUseCase(IUserService userService, IPasswordHasher hasher)
    {
        _userService = userService;
        _hasher = hasher;
    }

    public async Task<ResponseUserDto> ExecuteAsync(CreateUserDto dto)
    {
        string hashedPassword = _hasher.Hash(dto.Password);

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = hashedPassword,
            Role = dto.Role,
            Salary = dto.Salary,
            Position = dto.Position ?? "No Position",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            DepartmentId = (dto.DepartmentId.HasValue && dto.DepartmentId.Value > 0) ? dto.DepartmentId : null
        };

        var workInfo = new WorkInfo
        {
            State = State.Active,
            HireDate = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var createdUser = await _userService.InsertUserAsync(user, workInfo);

        return new ResponseUserDto
        {
            Id = createdUser.Id,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            Email = createdUser.Email,
            Role = createdUser.Role,
            Salary = createdUser.Salary,
            Position = createdUser.Position,
            DepartmentId = createdUser.DepartmentId,
            CreatedAt = createdUser.CreatedAt,
            UpdatedAt = createdUser.UpdatedAt
        };
    }
}
