using EmployeeManagement.Application.DTOs.UserWithEmployee;

namespace EmployeeManagement.Application.DTOs.Departments;

public class DepartmentResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? ManagerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ResponseUserDto? Manager { get; set; }
    public List<ResponseUserDto>? Users { get; set; }
}
