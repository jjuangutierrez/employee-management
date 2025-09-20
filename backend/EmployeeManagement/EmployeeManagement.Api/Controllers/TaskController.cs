using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Application.UsesCases.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly CreateTaskUseCase _createTaskUseCase;
    private readonly DeleteTaskUseCase _deleteTaskUseCase;
    private readonly GetTaskUseCase _getTaskUseCase;
    private readonly GetAllTaskByUserUseCase _getAllTaskByUserUseCase;
    private readonly UpdateTaskUseCase _updateTaskUseCase;

    public TaskController(CreateTaskUseCase createTaskUseCase, DeleteTaskUseCase deleteTaskUseCase, GetTaskUseCase getTasUseCase, GetAllTaskByUserUseCase getAllTaskByUserUseCase, UpdateTaskUseCase updateTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _deleteTaskUseCase = deleteTaskUseCase;
        _getTaskUseCase = getTasUseCase;
        _getAllTaskByUserUseCase = getAllTaskByUserUseCase;
        _updateTaskUseCase = updateTaskUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> Create(int userId, [FromBody] CreateTaskDto dto)
    {
        var result = await _createTaskUseCase.ExecuteAsync(userId, dto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponseDto>> Get(int id)
    {
        var result = await _getTaskUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<TaskResponseDto>> GetTasksByUser(int userId)
    {
        var result = await _getAllTaskByUserUseCase.ExecuteAsync(userId);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskResponseDto>> Update(int id, [FromBody] UpdateTaskDto dto)
    {
        var result = await _updateTaskUseCase.ExecuteAsync(id, dto);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskResponseDto>> Delete(int id)
    {
        var result = await _deleteTaskUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();
        
        return Ok(result);
    }

}
