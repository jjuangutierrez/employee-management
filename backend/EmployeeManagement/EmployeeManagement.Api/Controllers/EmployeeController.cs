using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly CreateEmployeeUseCase _createEmployeeUseCase;
    private readonly GetEmployeeUseCase _getEmployeeUseCase;
    private readonly UpdateEmployeeUseCase _updateEmployeeUseCase;
    private readonly DeleteEmployeeUseCase _deleteEmployeeUseCase;

    public EmployeeController(
        CreateEmployeeUseCase createEmployeeUseCase,
        GetEmployeeUseCase getEmployeeUseCase,
        UpdateEmployeeUseCase updateEmployeeUseCase,
        DeleteEmployeeUseCase deleteEmployeeUseCase

        )
    {
        _createEmployeeUseCase = createEmployeeUseCase;
        _getEmployeeUseCase = getEmployeeUseCase;
        _updateEmployeeUseCase = updateEmployeeUseCase;
        _deleteEmployeeUseCase = deleteEmployeeUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateEmployeeDto dto)
    {
        var result = await _createEmployeeUseCase.ExecuteAsync(dto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> Get(int id)
    {
        var result = await _getEmployeeUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeDto>> Update(int id, [FromBody] UpdateEmployeeDto dto)
    {
        var result = await _updateEmployeeUseCase.ExecuteAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EmployeeDto>> Delete(int id)
    {
        var result = await _deleteEmployeeUseCase.ExecuteAsync(id);
        return Ok(result);
    }
}
