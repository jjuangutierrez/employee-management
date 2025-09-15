using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.UseCases;
using EmployeeManagement.Application.UsesCases;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly CreateDepartmentUseCase _createDepartmentUseCase;
    private readonly GetDepartmentUseCase _getDepartmentUseCase;
    private readonly UpdateDepartmentUseCase _updateDepartmentUseCase;
    private readonly DeleteDepartmentUseCase _deleteDepartmentUseCase;

    public DepartmentController(
        CreateDepartmentUseCase createDepartmentUseCase,
        GetDepartmentUseCase getDepartmentUseCase,
        UpdateDepartmentUseCase updateDepartmentUseCase,
        DeleteDepartmentUseCase deleteDepartmentUseCase
        )
    {
        _createDepartmentUseCase = createDepartmentUseCase;
        _getDepartmentUseCase = getDepartmentUseCase;
        _updateDepartmentUseCase = updateDepartmentUseCase;
        _deleteDepartmentUseCase = deleteDepartmentUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> Create([FromBody] CreateDepartmentDto dto)
    {
        var result = await _createDepartmentUseCase.ExecuteAsync(dto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> Get(int id)
    {
        var result = await _getDepartmentUseCase.ExecuteAsync(id);
        if(result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DepartmentDto>> Update(int id, [FromBody] UpdateDepartmentDto dto)
    {
        var result = await _updateDepartmentUseCase.ExecuteAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DepartmentDto>> Delete(int id)
    {
        var result = await _deleteDepartmentUseCase.ExecuteAsync(id);
        return Ok(result);
    }

}
