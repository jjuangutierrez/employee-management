using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
    public TaskEntityStatus Status { get; set; } = TaskEntityStatus.Pending;
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public User User { get; set; } = null;
}
