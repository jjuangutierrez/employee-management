using AutoMapper;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Departments;

public class DeleteDepartmentUseCase
{
    private readonly IDepartmentService _departmentsService;
    private readonly IMapper _mapper;

    public DeleteDepartmentUseCase(IDepartmentService departmentsService, IMapper mapper)
    {
        _departmentsService = departmentsService;
        _mapper = mapper;
    }

    public async Task<DepartmentResponseDto> ExecuteAsync(int departmentId)
    {
        if (departmentId <= 0)
            throw new ArgumentException("department ID must be greater than zero", nameof(departmentId));

        var deletedTask = await _departmentsService.DeleteDepartmentAsync(departmentId);

        return _mapper.Map<DepartmentResponseDto>(deletedTask);
    }
}
