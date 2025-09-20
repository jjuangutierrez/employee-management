using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.DTOs.Tasks;

public class CreateTaskDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskEntityStatus Status { get; set; }
}
