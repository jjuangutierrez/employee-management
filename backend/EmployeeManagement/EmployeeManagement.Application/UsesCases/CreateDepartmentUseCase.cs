using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UseCases;

public class CreateDepartmentUseCase
{
    private readonly IDepartmentService _departmentService;

    public CreateDepartmentUseCase(IDepartmentService departmentService)
        => _departmentService = departmentService;

    public async Task<DepartmentDto> ExecuteAsync(CreateDepartmentDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required");

        // convert Dto to entidad
        Department department = new Department
        {
            Name = dto.Name,
            Description = dto.Description,
            ManagerId = dto.ManagerId,
            CreatedDate = DateTime.UtcNow
        };

        Department createdDepartment = await _departmentService.InsertDepartmentAsync(department);

        // convert entity to output Dto
        return new DepartmentDto
        {
            Id = createdDepartment.Id,
            Name = createdDepartment.Name,
            Description = createdDepartment.Description,
            ManagerId = createdDepartment.ManagerId,
            Employees = createdDepartment.Employees?.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                LastName = e.LastName,
                Email = e.Email,
                Position = e.Position,
                DepartmentName = createdDepartment.Name
            }).ToList() ?? new List<EmployeeDto>()
        };

    }
}
