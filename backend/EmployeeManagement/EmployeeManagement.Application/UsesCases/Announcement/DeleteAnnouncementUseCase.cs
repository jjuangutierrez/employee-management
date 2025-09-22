using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class DeleteAnnouncementUseCase
{
    private readonly IAnnouncementService _announcementService;

    public DeleteAnnouncementUseCase(IAnnouncementService announcementService)
    {
        _announcementService = announcementService ?? throw new ArgumentNullException(nameof(announcementService));
    }

    public async Task<AnnouncementResponseDto> ExecuteAsync(int announcementId)
    {
        if (announcementId <= 0)
            throw new ArgumentException("Announcement ID must be greater than zero", nameof(announcementId));

        var announcementToDelete = await _announcementService.GetAnnouncementAsync(announcementId);

        if (announcementToDelete == null)
            throw new KeyNotFoundException($"Announcement with ID {announcementId} not found");

        await _announcementService.DeleteAnnouncementAsync(announcementId);

        return new AnnouncementResponseDto
        {
            Id = announcementToDelete.Id,
            Title = announcementToDelete.Title,
            Description = announcementToDelete.Description,
            CreatedBy = announcementToDelete.CreatedBy,
            CreatedAt = announcementToDelete.CreatedAt,
            ExpiredAt = announcementToDelete.ExpiredAt,
            CreatedByName = announcementToDelete.User != null
                ? $"{announcementToDelete.User.FirstName} {announcementToDelete.User.LastName}".Trim()
                : string.Empty,
            User = announcementToDelete.User
        };
    }
}