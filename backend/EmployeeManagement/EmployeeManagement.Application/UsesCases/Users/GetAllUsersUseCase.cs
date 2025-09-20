using AutoMapper;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Users;

public class GetAllUsersUseCase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetAllUsersUseCase(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponseDto>> ExecuteAsync()
    {
        var users = await _userService.GetAllUsersAsync();

        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }
}