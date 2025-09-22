using AutoMapper;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class GetAllAnnouncementsUseCase
{
    private readonly IAnnouncementService _announcementService;

    public GetAllAnnouncementsUseCase(IAnnouncementService announcementService)
    {
        _announcementService = announcementService ?? throw new ArgumentNullException(nameof(announcementService));
    }

    public async Task<IEnumerable<AnnouncementResponseDto>> ExecuteAsync()
    {
        var announcements = await _announcementService.GetAllAnnouncementsAsync();

        return announcements.Select(announcement => new AnnouncementResponseDto
        {
            Id = announcement.Id,
            Title = announcement.Title,
            Description = announcement.Description,
            CreatedBy = announcement.CreatedBy,
            CreatedAt = announcement.CreatedAt,
            ExpiredAt = announcement.ExpiredAt,
            CreatedByName = announcement.User != null
                ? $"{announcement.User.FirstName} {announcement.User.LastName}".Trim()
                : string.Empty,
            User = announcement.User
        });
    }
}