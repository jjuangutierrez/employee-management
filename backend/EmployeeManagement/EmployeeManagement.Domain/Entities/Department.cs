namespace EmployeeManagement.Domain.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int? ManagerId { get; set; }
    public User? Manager { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}
