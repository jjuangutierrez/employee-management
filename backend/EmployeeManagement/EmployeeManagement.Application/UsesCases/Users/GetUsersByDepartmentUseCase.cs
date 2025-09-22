using EmployeeManagement.Application.Interfaces;

public class GetUsersByDepartmentUseCase
{
    private readonly IUserService _userService;

    public GetUsersByDepartmentUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IEnumerable<ResponseUserDto>> ExecuteAsync(int departmentId)
    {
        var users = await _userService.GetUsersByDepartmentAsync(departmentId);

        return users.Select(u => new ResponseUserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Role = u.Role,
            Salary = u.Salary,
            Position = u.Position,
            DepartmentId = u.DepartmentId,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt
        });
    }
}
