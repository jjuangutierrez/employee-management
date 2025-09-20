using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.Services;

public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;

    public AnnouncementService(IAnnouncementRepository announcementRepository)
        => _announcementRepository = announcementRepository;

    public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
    {
        return await _announcementRepository.GetAllAnnouncementsAsync();
    }

    public async Task<Announcement?> GetAnnouncementAsync(int announcementId)
    {
        var announcement = await _announcementRepository.GetAnnouncementAsync(announcementId);
        if (announcement == null)
            throw new KeyNotFoundException($"Announcement with ID {announcementId} not found");

        return announcement;
    }

    public async Task<Announcement> InsertAnnouncementAsync(Announcement announcement)
    {
        if (string.IsNullOrWhiteSpace(announcement.Title))
            throw new ArgumentException("Title cannot be empty");
        if (string.IsNullOrWhiteSpace(announcement.Description))
            throw new ArgumentException("Description cannot be empty");

        return await _announcementRepository.InsertAnnouncementAsync(announcement);
    }

    public async Task UpdateAnnouncementAsync(Announcement announcement)
    {
        if (announcement.Id <= 0)
            throw new ArgumentException("Invalid announcement ID");

        await _announcementRepository.UpdateAnnouncementAsync(announcement);
    }

    public async Task DeleteAnnouncementAsync(int announcementId)
    {
        if (announcementId <= 0)
            throw new ArgumentException("Invalid announcement ID");

        await _announcementRepository.DeleteAnnouncementAsync(announcementId);
    }
}
