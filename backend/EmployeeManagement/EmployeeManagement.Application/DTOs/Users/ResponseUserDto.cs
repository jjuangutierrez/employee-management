using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.DTOs.WorkInfo;

public class ResponseUserDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Enum Role { get; set; }
    public long Salary { get; set; }
    public string Position { get; set; }
    public int? DepartmentId { get; set; }

    public WorkInfoDto? WorkInfo { get; set; }

    public DepartmentResponseDto? Department { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
