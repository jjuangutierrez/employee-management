using AutoMapper;
using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Profiles;

public class AnnouncementProfile : Profile
{
    public AnnouncementProfile()
    {
        // CreateAnnouncementDto -> Announcement
        CreateMap<CreateAnnouncementDto, Announcement>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ExpiredAt, opt => opt.MapFrom(src =>
                src.ExpiredAt.HasValue ? src.ExpiredAt.Value : DateTime.UtcNow.AddDays(30)))
            .ForMember(dest => dest.User, opt => opt.Ignore());

        // Announcement -> AnnouncementResponseDto
        CreateMap<Announcement, AnnouncementResponseDto>()
            .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src =>
                src.User != null ? $"{src.User.FirstName} {src.User.LastName}" : string.Empty));

        // UpdateAnnouncementDto -> Announcement (para actualizaciones)
        CreateMap<UpdateAnnouncementDto, Announcement>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.ExpiredAt, opt => opt.MapFrom(src =>
                src.ExpiredAt.HasValue ? src.ExpiredAt.Value : DateTime.UtcNow.AddDays(30)));
    }
}