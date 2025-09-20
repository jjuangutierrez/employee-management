using AutoMapper;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Users;

public class DeleteUsersUseCase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public DeleteUsersUseCase(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

     public async Task<UserResponseDto> ExecuteAsync(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("User ID must be greater than zero", nameof(userId));

        var deletedUser = await _userService.DeleteUserAsync(userId);

        return _mapper.Map<UserResponseDto>(deletedUser);
    }
}