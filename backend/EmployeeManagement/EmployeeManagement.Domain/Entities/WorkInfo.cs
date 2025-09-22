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

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; }
}
