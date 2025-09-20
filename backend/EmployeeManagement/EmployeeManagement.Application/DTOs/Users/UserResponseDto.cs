using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.DTOs.WorkInfo;

public class UserResponseDto
{
    // User básico
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public WorkInfoDto? WorkInfo { get; set; }

    public DepartmentResponseDto? Department { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}