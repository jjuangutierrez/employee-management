using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

public class GetDepartmentUseCase
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentUseCase(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<DepartmentResponseDto> ExecuteAsync(int departmentId)
    {
        if (departmentId <= 0)
            throw new ArgumentException("Department ID must be greater than zero", nameof(departmentId));

        var department = await _departmentService.GetDepartmentAsync(departmentId);

        return MapToResponseDto(department);
    }

    private static DepartmentResponseDto MapToResponseDto(Department department)
    {
        return new DepartmentResponseDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ManagerId = department.ManagerId,
            CreatedAt = department.CreatedAt,
            UpdatedAt = department.UpdatedAt,
            Manager = department.Manager != null ? new ResponseUserDto
            {
                Id = department.Manager.Id,
                FirstName = department.Manager.FirstName,
                LastName = department.Manager.LastName,
                Email = department.Manager.Email,
                Role = department.Manager.Role,
                Salary = department.Manager.Salary,
                Position = department.Manager.Position,
                DepartmentId = department.Manager.DepartmentId,
                CreatedAt = department.Manager.CreatedAt,
                UpdatedAt = department.Manager.UpdatedAt
            } : null,
            Users = department.Users?.Select(u => new ResponseUserDto
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
                UpdatedAt = u.UpdatedAt
            }).ToList() ?? new List<ResponseUserDto>()
        };
    }
}
