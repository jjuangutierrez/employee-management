using EmployeeManagement.Application.DTOs.UserWithEmployee; // DTOs
using EmployeeManagement.Application.DTOs.WorkInfo;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

public class GetUserUseCase
{
    private readonly IUserService _userService;

    public GetUserUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResponseUserDto> ExecuteAsync(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user == null)
            return null!; // o lanza excepción si prefieres

        // Mapeo manual
        var dto = new ResponseUserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role,
            Salary = user.Salary,
            Position = user.Position,
            DepartmentId = user.DepartmentId,
            WorkInfo = user.WorkInfo == null ? null : new WorkInfoDto
            {
                Id = user.WorkInfo.Id,
                HireDate = user.WorkInfo.HireDate,
                State = user.WorkInfo.State,
                CreatedAt = user.WorkInfo.CreatedAt,
                UpdatedAt = user.WorkInfo.UpdatedAt
            },
            Department = user.Department == null ? null : new DepartmentResponseDto
            {
                Id = user.Department.Id,
                Name = user.Department.Name,
                ManagerId = user.Department.ManagerId
            },
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };

        return dto;
    }
}
