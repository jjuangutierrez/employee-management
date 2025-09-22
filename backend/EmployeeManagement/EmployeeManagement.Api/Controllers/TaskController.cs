using EmployeeManagement.Application.DTOs.Tasks;
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

    public TaskController(
        CreateTaskUseCase createTaskUseCase,
        DeleteTaskUseCase deleteTaskUseCase,
        GetTaskUseCase getTaskUseCase,
        GetAllTaskByUserUseCase getAllTaskByUserUseCase,
        UpdateTaskUseCase updateTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase ?? throw new ArgumentNullException(nameof(createTaskUseCase));
        _deleteTaskUseCase = deleteTaskUseCase ?? throw new ArgumentNullException(nameof(deleteTaskUseCase));
        _getTaskUseCase = getTaskUseCase ?? throw new ArgumentNullException(nameof(getTaskUseCase));
        _getAllTaskByUserUseCase = getAllTaskByUserUseCase ?? throw new ArgumentNullException(nameof(getAllTaskByUserUseCase));
        _updateTaskUseCase = updateTaskUseCase ?? throw new ArgumentNullException(nameof(updateTaskUseCase));
    }

    [HttpPost("user/{userId}")]
    [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TaskResponseDto>> CreateTask(int userId, [FromBody] CreateTaskDto createTaskDto)
    {
        try
        {
            var result = await _createTaskUseCase.ExecuteAsync(userId, createTaskDto);
            return CreatedAtAction(nameof(GetTask), new { id = result.Id }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskResponseDto>> GetTask(int id)
    {
        try
        {
            var result = await _getTaskUseCase.ExecuteAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Task with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(IEnumerable<TaskResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetTasksByUser(int userId)
    {
        try
        {
            var result = await _getAllTaskByUserUseCase.ExecuteAsync(userId);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskResponseDto>> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        try
        {
            var result = await _updateTaskUseCase.ExecuteAsync(id, updateTaskDto);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Task with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskResponseDto>> DeleteTask(int id)
    {
        try
        {
            var result = await _deleteTaskUseCase.ExecuteAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Task with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}