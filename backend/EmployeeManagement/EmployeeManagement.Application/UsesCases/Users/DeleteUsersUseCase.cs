using EmployeeManagement.Application.Interfaces;

public class DeleteUsersUseCase
{
    private readonly IUserService _userService;

    public DeleteUsersUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResponseUserDto> ExecuteAsync(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("User ID must be greater than zero", nameof(userId));

        var deletedUser = await _userService.DeleteUserAsync(userId);

        return new ResponseUserDto
        {
            Id = deletedUser.Id,
            FirstName = deletedUser.FirstName,
            LastName = deletedUser.LastName,
            Email = deletedUser.Email,
            Role = deletedUser.Role,
            Salary = deletedUser.Salary,
            Position = deletedUser.Position,
            DepartmentId = deletedUser.DepartmentId,
            CreatedAt = deletedUser.CreatedAt,
            UpdatedAt = deletedUser.UpdatedAt
        };
    }
}
