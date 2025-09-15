using EmployeeManagement.Domain.Enums;

public class CreateEmployeeDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DocumentNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Phone { get; set; }
    public string AlternatePhone { get; set; }
    public int Salary { get; set; }
    public string Position { get; set; }
    public int DepartmentId { get; set; }
    public Role Role { get; set; }
    public State State { get; set; }
}
