using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.UsesCases.Departments;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly CreateDepartmentUseCase _createDepartmentUseCase;
    private readonly DeleteDepartmentUseCase _deleteDepartmentUseCase;
    private readonly GetAllDepartmentsUseCase _getAllDepartmentsUseCase;
    private readonly GetDepartmentUseCase _getDepartmentUseCase;
    private readonly UpdateDepartmentUseCase _updateDepartmentUseCase;

    public DepartmentController(
        CreateDepartmentUseCase createDepartmentUseCase,
        DeleteDepartmentUseCase deleteDepartmentUseCase,
        GetAllDepartmentsUseCase getAllDepartmentsUseCase,
        GetDepartmentUseCase getDepartmentUseCase,
        UpdateDepartmentUseCase updateDepartmentUseCase)
    {
        _createDepartmentUseCase = createDepartmentUseCase;
        _deleteDepartmentUseCase = deleteDepartmentUseCase;
        _getAllDepartmentsUseCase = getAllDepartmentsUseCase;
        _getDepartmentUseCase = getDepartmentUseCase;
        _updateDepartmentUseCase = updateDepartmentUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentResponseDto>> Create([FromBody] CreateDepartmentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _createDepartmentUseCase.ExecuteAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentResponseDto>> Get(int id)
    {
        try
        {
            var result = await _getDepartmentUseCase.ExecuteAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Department with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentResponseDto>>> GetAllDepartments()
    {
        var result = await _getAllDepartmentsUseCase.ExecuteAsync();

        if (!result.Any())
            return NotFound("No departments found");

        return Ok(result);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<DepartmentResponseDto>> Update(int id, [FromBody] UpdateDepartmentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _updateDepartmentUseCase.ExecuteAsync(id, dto);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Department with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DepartmentResponseDto>> Delete(int id)
    {
        try
        {
            var result = await _deleteDepartmentUseCase.ExecuteAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Department with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}