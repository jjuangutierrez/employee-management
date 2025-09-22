using EmployeeManagement.Application.DTOs.WorkInfo;
using EmployeeManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CreateUserDto
{
    [Required]
    [MaxLength(32)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(125)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    [MaxLength(64)]
    public string Password { get; set; } = string.Empty;

    public Role Role { get; set; } = Role.Employee;

    [Range(0, 99999999)]
    public long Salary { get; set; } = 0;

    [MaxLength(64)]
    public string? Position { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? DepartmentId { get; set; } = null;
}
