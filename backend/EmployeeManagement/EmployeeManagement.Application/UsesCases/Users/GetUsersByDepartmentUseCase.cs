using AutoMapper;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UseCases.Users;

public class GetUsersByDepartmentUseCase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetUsersByDepartmentUseCase(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponseDto>> ExecuteAsync(int departmentId)
    {
        var users = await _userService.GetUsersByDepartmentAsync(departmentId);

        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }
}
