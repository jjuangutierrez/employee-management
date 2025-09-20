using AutoMapper;
using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class GetAllAnnouncementsUseCase
{
    private readonly IAnnouncementService _service;
    private readonly IMapper _mapper;

    public GetAllAnnouncementsUseCase(IAnnouncementService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnnouncementResponseDto>> ExecuteAsync()
    {
        var announcements = await _service.GetAllAnnouncementsAsync();
        return _mapper.Map<IEnumerable<AnnouncementResponseDto>>(announcements);
    }
}