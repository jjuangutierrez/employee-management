using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data.Repositories;

public class AnnouncementRepository : IAnnouncementRepository, IDisposable
{
    private readonly AppDbContext _context;

    public AnnouncementRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
    {
        return await _context.Announcements.ToListAsync();
    }

    public async Task<Announcement?> GetAnnouncementAsync(int announcementId)
    {
        return await _context.Announcements.FindAsync(announcementId);
    }

    public async Task<Announcement> InsertAnnouncementAsync(Announcement announcement)
    {
        announcement.CreatedAt = DateTime.UtcNow;
        await _context.Announcements.AddAsync(announcement);
        await _context.SaveChangesAsync();
        return announcement;
    }

    public async Task UpdateAnnouncementAsync(Announcement announcement)
    {
        var existing = await _context.Announcements.FindAsync(announcement.Id);
        if (existing == null)
            throw new KeyNotFoundException($"Announcement with ID {announcement.Id} not found");

        existing.Title = announcement.Title;
        existing.Description = announcement.Description;
        existing.ExpiredAt = announcement.ExpiredAt;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAnnouncementAsync(int announcementId)
    {
        var announcement = await _context.Announcements.FindAsync(announcementId);
        if (announcement == null)
            throw new KeyNotFoundException($"Announcement with ID {announcementId} not found");

        _context.Announcements.Remove(announcement);
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
