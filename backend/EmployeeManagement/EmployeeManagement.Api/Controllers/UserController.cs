using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Application.UseCases.Users;
using EmployeeManagement.Application.UsesCases.Users;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly CreateUsersUseCase _createUserUseCase;
    private readonly GetUserUseCase _getUserUseCase;
    private readonly GetAllUsersUseCase _getAllUsersUseCase;
    private readonly UpdateUserUseCase _updateUserUseCase;
    private readonly DeleteUsersUseCase _deleteUserUseCase;
    private readonly GetUsersByDepartmentUseCase _getUsersByDepartmentUseCase;

    public UserController(
        CreateUsersUseCase createUserUseCase,
        GetUserUseCase getUserUseCase,
        GetAllUsersUseCase getAllUsersUseCase,
        UpdateUserUseCase updateUserUseCase,
        DeleteUsersUseCase deleteUserUseCase,
        GetUsersByDepartmentUseCase getUsersByDepartmentUseCase
        )
    {
        _createUserUseCase = createUserUseCase;
        _getUserUseCase = getUserUseCase;
        _getAllUsersUseCase = getAllUsersUseCase;
        _updateUserUseCase = updateUserUseCase;
        _deleteUserUseCase = deleteUserUseCase;
        _getUsersByDepartmentUseCase = getUsersByDepartmentUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> Create([FromBody] CreateUserDto dto)
    {
        var result = await _createUserUseCase.ExecuteAsync(dto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> Get(int id)
    {
        var result = await _getUserUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
    {
        var users = await _getAllUsersUseCase.ExecuteAsync();

        if (users == null || !users.Any())
            return NotFound("No users found");

        return Ok(users);
    }

    [HttpGet("department/{id}")]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsersByDepartment(int departmentId)
    {
        var users = await _getUsersByDepartmentUseCase.ExecuteAsync(departmentId);

        if (users == null || !users.Any())
            return NotFound($"No users found in department {departmentId}");

        return Ok(users);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponseDto>> Update(int id, [FromBody] UpdateUserDto dto)
    {
        var result = await _updateUserUseCase.ExecuteAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserResponseDto>> Delete(int id)
    {
        var result = await _deleteUserUseCase.ExecuteAsync(id);
        return Ok(result);
    }


}
