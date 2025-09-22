using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Application.DTOs.WorkInfo;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Domain.Entities;

public class GetAllUsersUseCase
{
    private readonly IUserService _userService;

    public GetAllUsersUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IEnumerable<ResponseUserDto>> ExecuteAsync()
    {
        var users = await _userService.GetAllUsersAsync();

        return users.Select(u => new ResponseUserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Role = u.Role,
            Salary = u.Salary,
            Position = u.Position,
            DepartmentId = u.DepartmentId,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt,

            WorkInfo = u.WorkInfo == null ? null : new WorkInfoDto
            {
                Id = u.WorkInfo.Id,
                Age = u.WorkInfo.Age,
                DocumentNumber = u.WorkInfo.DocumentNumber,
                DocumentType = u.WorkInfo.DocumentType,
                HireDate = u.WorkInfo.HireDate,
                State = u.WorkInfo.State,
                Phone = u.WorkInfo.Phone,
                AlternatePhone = u.WorkInfo.AlternatePhone,
                CreatedAt = u.WorkInfo.CreatedAt,
                UpdatedAt = u.WorkInfo.UpdatedAt
            },

            Department = u.Department == null ? null : new DepartmentResponseDto
            {
                Id = u.Department.Id,
                Name = u.Department.Name,
                ManagerId = u.Department.ManagerId
            }
        });
    }
}
