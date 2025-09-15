namespace EmployeeManagement.Application.DTOs;

public class UpdateDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ManagerId { get; set; }
}
