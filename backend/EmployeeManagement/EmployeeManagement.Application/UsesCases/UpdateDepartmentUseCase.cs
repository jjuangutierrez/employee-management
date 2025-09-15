using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UseCases;

public class UpdateDepartmentUseCase
{
    private readonly IDepartmentService _departmentService;

    public UpdateDepartmentUseCase(IDepartmentService departmentService)
        => _departmentService = departmentService;

    public async Task<DepartmentDto> ExecuteAsync(int id, UpdateDepartmentDto dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto));
        if (id <= 0) throw new ArgumentException("Invalid Department ID");

        var existing = await _departmentService.GetDepartmentAsync(id);
        if (existing == null) throw new KeyNotFoundException("Department not found");

        existing.Name = dto.Name;
        existing.Description = dto.Description;
        existing.ManagerId = dto.ManagerId;

        var updated = await _departmentService.UpdateDepartmentAsync(existing);

        return new DepartmentDto
        {
            Id = updated.Id,
            Name = updated.Name,
            Description = updated.Description,
        };
    }

}
