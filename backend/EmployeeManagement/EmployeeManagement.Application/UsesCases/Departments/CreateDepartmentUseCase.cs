using AutoMapper;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Departments;

public class CreateDepartmentUseCase
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;

    public CreateDepartmentUseCase(IDepartmentService departmentsService, IMapper mapper)
    {
        _departmentService = departmentsService;
        _mapper = mapper;
    }

    public async Task<DepartmentResponseDto> ExecuteAsync(CreateDepartmentDto departmentDto)
    {
        var department = _mapper.Map<Department>(departmentDto);

        var createdDepartment = await _departmentService.InsertDepartmentAsync(department);

        return _mapper.Map<DepartmentResponseDto>(createdDepartment);
    }
}
