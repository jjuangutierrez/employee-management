using AutoMapper;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UsesCases.Departments;

public class GetAllDepartmentsUseCase
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;

    public GetAllDepartmentsUseCase(IDepartmentService departmentService, IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentResponseDto>> ExecuteAsync()
    {
        var department = await _departmentService.GetAllDepartmentsAsync();

        return _mapper.Map<IEnumerable<DepartmentResponseDto>>(department);
    }
}
