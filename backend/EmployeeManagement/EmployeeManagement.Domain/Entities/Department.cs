namespace EmployeeManagement.Domain.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? ManagerId { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
