using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.DTOs.Tasks;

public class UpdateTaskDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TaskEntityStatus? Status { get; set; }
}
