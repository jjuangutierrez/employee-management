using AutoMapper;
using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UseCases.Announcement;

public class UpdateAnnouncementUseCase
{
    private readonly IAnnouncementService _service;
    private readonly IMapper _mapper;

    public UpdateAnnouncementUseCase(IAnnouncementService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task ExecuteAsync(int id, UpdateAnnouncementDto dto)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid announcement ID");

        // Obtener la entidad existente
        var existing = await _service.GetAnnouncementAsync(id);
        if (existing == null)
            throw new KeyNotFoundException($"Announcement with ID {id} not found");

        _mapper.Map(dto, existing);
        existing.Id = id;

        await _service.UpdateAnnouncementAsync(existing);
    }
}