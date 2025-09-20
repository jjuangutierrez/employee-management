namespace EmployeeManagement.Domain.Entities;

public class Announcement
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }

    // user 1:N
    public User User { get; set; } = null;
    public int CreatedBy { get; set; } // who create this announcement
}
