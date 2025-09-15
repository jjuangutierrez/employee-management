using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UsesCases;

public class GetDepartmentUseCase
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentUseCase(IDepartmentService departmentService)
        => _departmentService = departmentService;

    public async Task<DepartmentDto> ExecuteAsync(int departmentId)
    {
        var department = await _departmentService.GetDepartmentAsync(departmentId);

        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ManagerId = department.ManagerId
        };
    }
}
