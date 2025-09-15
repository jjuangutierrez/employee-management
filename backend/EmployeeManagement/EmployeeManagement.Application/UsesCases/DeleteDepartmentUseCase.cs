

using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UsesCases;

public class DeleteDepartmentUseCase
{
    private readonly IDepartmentService _departmentService;

    public DeleteDepartmentUseCase(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<DepartmentDto> ExecuteAsync(int departmentId)
    {
        Department department = await _departmentService.DeleteDepartmentAsync(departmentId);

        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ManagerId = department.ManagerId,
        };

    }
}
