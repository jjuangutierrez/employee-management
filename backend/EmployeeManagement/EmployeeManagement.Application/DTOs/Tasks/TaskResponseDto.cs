namespace EmployeeManagement.Application.DTOs.Tasks;

using EmployeeManagement.Domain.Enums;

public class TaskResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public TaskEntityStatus Status { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public int UserId { get; set; }
    public string UserName { get; set; } 
}