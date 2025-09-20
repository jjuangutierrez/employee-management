using EmployeeManagement.Domain.Entities;

public class AnnouncementResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }

    public string CreatedByName { get; set; } = string.Empty;

    public User User { get; set; }
}
