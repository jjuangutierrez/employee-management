using AutoMapper;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Interfaces;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.UsesCases.Departments;

public class GetDepartmentUseCase
{
    private readonly IDepartmentService _departmentsService;
    private readonly IMapper _mapper;

    public GetDepartmentUseCase(IDepartmentService departmentsService, IMapper mapper)
    {
        _departmentsService = departmentsService;
        _mapper = mapper;
    }

    public async Task<DepartmentResponseDto> ExecuteAsync(int departmentId)
    {
        if (departmentId <= 0)
            throw new ArgumentException("Department ID must be greater than zero", nameof(departmentId));

        var user = await _departmentsService.GetDepartmentAsync(departmentId);

        return _mapper.Map<DepartmentResponseDto>(user);
    }
}
