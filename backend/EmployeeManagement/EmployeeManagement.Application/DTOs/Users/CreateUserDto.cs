using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class CreateUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
    public int Salary { get; set; }
    public string Position { get; set; }
    public int? DepartmentId { get; set; }
}