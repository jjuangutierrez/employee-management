using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.DTOs.WorkInfo;

public class UpdateWorkInfoDto
{
    public int Age { get; set; }
    public long DocumentNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public DateTime HireDate { get; set; }
    public long Phone { get; set; }
    public long AlternatePhone { get; set; }
    public long Salary { get; set; }
    public string Position { get; set; }
}
