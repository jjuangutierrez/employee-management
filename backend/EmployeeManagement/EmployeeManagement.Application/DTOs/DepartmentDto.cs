using EmployeeManagement.Application.DTOs;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? ManagerId { get; set; }
    public List<EmployeeDto> Employees { get; set; } = new();
}
