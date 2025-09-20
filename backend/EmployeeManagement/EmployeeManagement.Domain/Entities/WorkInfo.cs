using EmployeeManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities;
public class WorkInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? Age { get; set; }
    public long? DocumentNumber { get; set; }
    public DocumentType? DocumentType { get; set; }
    public DateTime? HireDate { get; set; }
    public State? State { get; set; }
    public long? Phone { get; set; }
    public long? AlternatePhone { get; set; }
    public long Salary { get; set; }
    public string Position { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public User User { get; set; }
}
