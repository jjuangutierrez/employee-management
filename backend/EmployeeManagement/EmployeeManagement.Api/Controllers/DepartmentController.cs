using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.UsesCases.Departments;
using EmployeeManagement.Application.UsesCases.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController: ControllerBase
{
    private readonly CreateDepartmentUseCase _createDepartmentUseCase;
    private readonly DeleteDepartmentUseCase _deleteDepartmentUseCase;
    private readonly GetAllDepartmentsUseCase _getAllDepartmentsUseCase;
    private readonly GetDepartmentUseCase _getDepartmetnUseCase;
    // misiing updateddepartmentusecase

    public DepartmentController(CreateDepartmentUseCase createDepartmentUseCase, DeleteDepartmentUseCase deleteDepartmentUseCase, GetAllDepartmentsUseCase getAllDepartmentsUseCase, GetDepartmentUseCase getDepartmentUseCase)
    {
        _createDepartmentUseCase = createDepartmentUseCase;
        _deleteDepartmentUseCase = deleteDepartmentUseCase;
        _getAllDepartmentsUseCase = getAllDepartmentsUseCase;
        _getDepartmetnUseCase = getDepartmentUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentResponseDto>> Create([FromBody] CreateDepartmentDto dto)
    {
        var result = await _createDepartmentUseCase.ExecuteAsync(dto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentResponseDto>> Get(int id)
    {
        var result = await _getDepartmetnUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<DepartmentResponseDto>> GetAllDepartments()
    {
        var result = await _getAllDepartmentsUseCase.ExecuteAsync();
        if (result == null) return NotFound();
        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<DepartmentResponseDto>> Delete(int id)
    {
        var result = await _deleteDepartmentUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();

        return Ok(result);
    }
}
