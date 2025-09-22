using AutoMapper;
using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class UpdateAnnouncementUseCase
{
    private readonly IAnnouncementService _announcementService;

    public UpdateAnnouncementUseCase(IAnnouncementService announcementService)
    {
        _announcementService = announcementService ?? throw new ArgumentNullException(nameof(announcementService));
    }

    public async Task<AnnouncementResponseDto> ExecuteAsync(int announcementId, UpdateAnnouncementDto updateAnnouncementDto)
    {
        if (announcementId <= 0)
            throw new ArgumentException("Announcement ID must be greater than zero", nameof(announcementId));

        if (updateAnnouncementDto == null)
            throw new ArgumentNullException(nameof(updateAnnouncementDto));

        var existingAnnouncement = await _announcementService.GetAnnouncementAsync(announcementId);

        if (existingAnnouncement == null)
            throw new KeyNotFoundException($"Announcement with ID {announcementId} not found");

        if (!string.IsNullOrWhiteSpace(updateAnnouncementDto.Title))
            existingAnnouncement.Title = updateAnnouncementDto.Title.Trim();

        if (!string.IsNullOrWhiteSpace(updateAnnouncementDto.Description))
            existingAnnouncement.Description = updateAnnouncementDto.Description.Trim();

        if (updateAnnouncementDto.ExpiredAt.HasValue)
            existingAnnouncement.ExpiredAt = updateAnnouncementDto.ExpiredAt.Value;

        await _announcementService.UpdateAnnouncementAsync(existingAnnouncement);

        return new AnnouncementResponseDto
        {
            Id = existingAnnouncement.Id,
            Title = existingAnnouncement.Title,
            Description = existingAnnouncement.Description,
            CreatedBy = existingAnnouncement.CreatedBy,
            CreatedAt = existingAnnouncement.CreatedAt,
            ExpiredAt = existingAnnouncement.ExpiredAt,
            CreatedByName = existingAnnouncement.User != null
                ? $"{existingAnnouncement.User.FirstName} {existingAnnouncement.User.LastName}".Trim()
                : string.Empty,
            User = existingAnnouncement.User
        };
    }
}