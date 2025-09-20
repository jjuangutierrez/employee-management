using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class DeleteAnnouncementUseCase
{
    private readonly IAnnouncementService _service;

    public DeleteAnnouncementUseCase(IAnnouncementService service)
    {
        _service = service;
    }

    public async Task ExecuteAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid announcement ID");

        await _service.DeleteAnnouncementAsync(id);
    }
}