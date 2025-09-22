using AutoMapper;
using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class CreateAnnouncementUseCase
{
    private readonly IAnnouncementService _announcementService;

    public CreateAnnouncementUseCase(IAnnouncementService announcementService)
    {
        _announcementService = announcementService ?? throw new ArgumentNullException(nameof(announcementService));
    }

    public async Task<AnnouncementResponseDto> ExecuteAsync(CreateAnnouncementDto createAnnouncementDto)
    {
        if (createAnnouncementDto == null)
            throw new ArgumentNullException(nameof(createAnnouncementDto));

        if (createAnnouncementDto.CreatedBy <= 0)
            throw new ArgumentException("CreatedBy must be a valid user ID", nameof(createAnnouncementDto));

        var announcement = new EmployeeManagement.Domain.Entities.Announcement
        {
            Title = createAnnouncementDto.Title?.Trim() ?? string.Empty,
            Description = createAnnouncementDto.Description?.Trim() ?? string.Empty,
            CreatedBy = createAnnouncementDto.CreatedBy,
            ExpiredAt = createAnnouncementDto.ExpiredAt ?? DateTime.UtcNow.AddDays(30) // Default 30 days
        };

        var createdAnnouncement = await _announcementService.InsertAnnouncementAsync(announcement);

        return new AnnouncementResponseDto
        {
            Id = createdAnnouncement.Id,
            Title = createdAnnouncement.Title,
            Description = createdAnnouncement.Description,
            CreatedBy = createdAnnouncement.CreatedBy,
            CreatedAt = createdAnnouncement.CreatedAt,
            ExpiredAt = createdAnnouncement.ExpiredAt,
            CreatedByName = createdAnnouncement.User != null
                ? $"{createdAnnouncement.User.FirstName} {createdAnnouncement.User.LastName}".Trim()
                : string.Empty,
            User = createdAnnouncement.User
        };
    }
}