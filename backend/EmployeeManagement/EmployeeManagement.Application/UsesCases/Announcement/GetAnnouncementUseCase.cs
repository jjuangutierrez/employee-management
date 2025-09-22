using AutoMapper;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class GetAnnouncementUseCase
{
    private readonly IAnnouncementService _announcementService;

    public GetAnnouncementUseCase(IAnnouncementService announcementService)
    {
        _announcementService = announcementService ?? throw new ArgumentNullException(nameof(announcementService));
    }

    public async Task<AnnouncementResponseDto> ExecuteAsync(int announcementId)
    {
        if (announcementId <= 0)
            throw new ArgumentException("Announcement ID must be greater than zero", nameof(announcementId));

        var announcement = await _announcementService.GetAnnouncementAsync(announcementId);

        if (announcement == null)
            throw new KeyNotFoundException($"Announcement with ID {announcementId} not found");

        return new AnnouncementResponseDto
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
        };
    }
}
