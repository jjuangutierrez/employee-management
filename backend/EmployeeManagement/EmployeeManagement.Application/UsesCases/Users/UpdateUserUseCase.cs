using AutoMapper;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Users;
public class UpdateUserUseCase
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher _hasher;
    private readonly IMapper _mapper;

    public UpdateUserUseCase(IUserService userService, IPasswordHasher hasher, IMapper mapper)
    {
        _userService = userService;
        _hasher = hasher;
        _mapper = mapper;
    }

    public async Task<UserResponseDto?> ExecuteAsync(int id, UpdateUserDto dto)
    {
        var existingUser = await _userService.GetUserAsync(id);
        if (existingUser == null) return null;

        _mapper.Map(dto, existingUser);

        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            existingUser.Password = _hasher.Hash(dto.Password);
        }

        if (dto.WorkInfo != null && existingUser.WorkInfo != null)
        {
            _mapper.Map(dto.WorkInfo, existingUser.WorkInfo);
        }

        var updatedUser = await _userService.UpdateUserAsync(existingUser, existingUser.WorkInfo);

        return _mapper.Map<UserResponseDto>(updatedUser);
    }

}