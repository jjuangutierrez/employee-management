using AutoMapper;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.UsesCases.Departments;


public class CreateDepartmentUseCase
{
    private readonly IDepartmentService _departmentService;

    public CreateDepartmentUseCase(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<DepartmentResponseDto> ExecuteAsync(CreateDepartmentDto departmentDto)
    {
        var department = new Department
        {
            Name = departmentDto.Name,
            Description = departmentDto.Description,
            ManagerId = departmentDto.ManagerId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var createdDepartment = await _departmentService.InsertDepartmentAsync(department);

        return MapToResponseDto(createdDepartment);
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