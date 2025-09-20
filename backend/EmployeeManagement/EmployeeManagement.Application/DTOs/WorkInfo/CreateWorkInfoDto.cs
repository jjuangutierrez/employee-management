
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.DTOs.WorkInfo;

public class CreateWorkInfoDto
{
    public int Age { get; set; }
    public long DocumentNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public DateTime? HireDate { get; set; }
    public long Phone { get; set; }
    public long? AlternatePhone { get; set; }
    public long Salary { get; set; } // no null
    public string Position { get; set; } = string.Empty; // no null
}
