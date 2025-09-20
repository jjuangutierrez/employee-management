using EmployeeManagement.Application.DTOs.WorkInfo;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.DTOs.UserWithEmployee;

public class UpdateUserDto
{
    // User
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Role? Role { get; set; }
    public int? DepartmentId { get; set; }

    public UpdateWorkInfoDto? WorkInfo { get; set; }
}

