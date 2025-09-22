using EmployeeManagement.Application.DTOs.WorkInfo;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs.UserWithEmployee;

public class UpdateUserDto
{
    [MaxLength(32)]
    public string? FirstName { get; set; }

    [MaxLength(32)]
    public string? LastName { get; set; }

    [MaxLength(125)]
    [EmailAddress]
    public string? Email { get; set; }

    [MinLength(6)]
    [MaxLength(64)]
    public string? Password { get; set; }

    public long? Salary {  get; set; }
    public string? Position { get; set; }

    public Role? Role { get; set; }
    public int? DepartmentId { get; set; }

    public UpdateWorkInfoDto? WorkInfo { get; set; }
}

