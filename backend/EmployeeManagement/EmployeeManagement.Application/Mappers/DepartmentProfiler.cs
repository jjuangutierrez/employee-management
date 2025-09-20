using AutoMapper;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Mappers;
public class DepartmentProfiler : Profile
{
    public DepartmentProfiler()
    {
        // CreateDepartmentDto -> Department
        CreateMap<CreateDepartmentDto, Department>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Manager, opt => opt.Ignore())
            .ForMember(dest => dest.Users, opt => opt.Ignore())
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src =>
                src.ManagerId.HasValue && src.ManagerId.Value > 0 ? src.ManagerId : null));


        // UpdateDepartmentDto -> Department
        CreateMap<UpdateDepartmentDto, Department>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Manager, opt => opt.Ignore())
            .ForMember(dest => dest.Users, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        // Department -> DepartmentResponseDto
        CreateMap<Department, DepartmentResponseDto>()
            .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager))
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Users));
    }
}