
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.DTOs.Announcement;

public class UpdateAnnouncementDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateTime? ExpiredAt { get; set; }
}
