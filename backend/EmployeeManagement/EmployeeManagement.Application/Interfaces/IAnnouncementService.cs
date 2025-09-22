using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces;

public interface IAnnouncementService
{
    Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync();
    Task<Announcement?> GetAnnouncementAsync(int announcementId);
    Task<Announcement> InsertAnnouncementAsync(Announcement announcement);
    Task UpdateAnnouncementAsync(Announcement announcement);
    Task DeleteAnnouncementAsync(int announcementId);
}
