using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs.Departments;
public class CreateDepartmentDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int? ManagerId { get; set; }
}