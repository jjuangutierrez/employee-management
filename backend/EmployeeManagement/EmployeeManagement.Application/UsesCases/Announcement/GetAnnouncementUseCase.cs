using AutoMapper;
using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class GetAnnouncementUseCase
{
    private readonly IAnnouncementService _service;
    private readonly IMapper _mapper;

    public GetAnnouncementUseCase(IAnnouncementService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<AnnouncementResponseDto?> ExecuteAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid announcement ID");

        var announcement = await _service.GetAnnouncementAsync(id);
        return announcement != null ? _mapper.Map<AnnouncementResponseDto>(announcement) : null;
    }
}
