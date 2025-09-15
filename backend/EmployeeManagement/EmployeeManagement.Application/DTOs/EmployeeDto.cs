using EmployeeManagement.Domain.Enums;

public class EmployeeDto 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string LastName { get; set; } 
    public int Age { get; set; } 
    public int DocumentNumber { get; set; } 
    public string DocumentType { get; set; } 
    public DateTime HireDate { get; set; } 
    public string Role { get; set; } 
    public string State { get; set; } 
    public string Email { get; set; } 
    public int Phone { get; set; } 
    public string AlternatePhone { get; set; } 
    public int Salary { get; set; } 
    public string Position { get; set; } 
    public string DepartmentName { get; set; } 
}