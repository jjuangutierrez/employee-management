using AutoMapper;
using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class CreateAnnouncementUseCase
{
    private readonly IAnnouncementService _service;
    private readonly IMapper _mapper;

    public CreateAnnouncementUseCase(IAnnouncementService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<AnnouncementResponseDto> ExecuteAsync(CreateAnnouncementDto dto)
    {
        if (dto.CreatedBy <= 0)
            throw new ArgumentException("CreatedBy must be a valid user ID");

        var announcement = _mapper.Map<Domain.Entities.Announcement>(dto);
        var created = await _service.InsertAnnouncementAsync(announcement);
        return _mapper.Map<AnnouncementResponseDto>(created);
    }
}