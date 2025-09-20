using AutoMapper;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Application.DTOs.WorkInfo;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Users;

public class CreateUsersUseCase
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher _hasher;
    private readonly IMapper _mapper;

    public CreateUsersUseCase(IUserService userService, IPasswordHasher hasher, IMapper mapper)
    {
        _userService = userService;
        _hasher = hasher;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> ExecuteAsync(CreateUserDto dto)
    {
        // 1. Business rules ...
        // 2. Hash password
        string hashedPassword = _hasher.Hash(dto.Password);

        var user = _mapper.Map<User>(dto);
        user.Password = hashedPassword;
        user.CreatedAt = DateTime.UtcNow;
        user.UpdateAt = DateTime.UtcNow;

        var workInfo = _mapper.Map<WorkInfo>(dto);
        workInfo.CreateAt = DateTime.UtcNow;
        workInfo.UpdateAt = DateTime.UtcNow;

        user.WorkInfo = workInfo;

        User createdUser = await _userService.InsertUserAsync(user);

        return _mapper.Map<UserResponseDto>(createdUser);
    }
}