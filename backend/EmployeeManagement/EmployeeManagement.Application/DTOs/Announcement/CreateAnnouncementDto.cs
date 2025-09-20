using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs.Announcement;

public class CreateAnnouncementDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int CreatedBy { get; set; }

    public DateTime? ExpiredAt { get; set; }
}