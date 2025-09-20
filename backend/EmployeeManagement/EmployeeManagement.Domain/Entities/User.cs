using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    // 1:N
    public ICollection<Department> ManagedDepartments { get; set; } = new List<Department>();

    public WorkInfo WorkInfo { get; set; }

}
