namespace EmployeeManagement.Application.DTOs.WorkInfo;

public class WorkInfoDto
{
    public int userId { get; set; }
    public int Age { get; set; }
    public long DocumentNumber { get; set; }
    public string Position { get; set; }
    public long Salary { get; set; } 

    public DateTime CreatedAt { get; set; }
}
