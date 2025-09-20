using AutoMapper;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Application.DTOs.WorkInfo;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Mappers;

public class UserProfiler : Profile
{
    public UserProfiler()
    {
        // User -> UserResponseDto (ÚNICO MAPEO)
        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
            .ForMember(dest => dest.WorkInfo, opt => opt.MapFrom(src => src.WorkInfo))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src =>
                src.Department != null ? MapDepartmentSimple(src.Department) : null))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdateAt));

        // WorkInfo -> WorkInfoDto
        CreateMap<WorkInfo, WorkInfoDto>();

        // CreateUserDto -> User
        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.WorkInfo, opt => opt.Ignore())
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src =>
                src.DepartmentId.HasValue && src.DepartmentId.Value > 0 ? src.DepartmentId : null));

        // CreateUserDto -> WorkInfo
        CreateMap<CreateUserDto, WorkInfo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore());

        // UpdateUserDto -> User
        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
            .ForMember(dest => dest.WorkInfo, opt => opt.Ignore())
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src =>
                src.DepartmentId.HasValue && src.DepartmentId.Value > 0 ? src.DepartmentId : null));

        // UpdateWorkInfoDto -> WorkInfo
        CreateMap<UpdateWorkInfoDto, WorkInfo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }

    private DepartmentResponseDto MapDepartmentSimple(Department department)
    {
        return new DepartmentResponseDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt,
            UpdatedAt = department.UpdatedAt,
            Manager = null,
            Employees = null
        };
    }
}