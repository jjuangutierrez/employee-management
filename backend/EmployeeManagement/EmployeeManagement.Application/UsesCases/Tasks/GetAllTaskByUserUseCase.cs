using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class GetAllTaskByUserUseCase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public GetAllTaskByUserUseCase(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskResponseDto>> ExecuteAsync(int userId)
    {
        var tasks = await _taskService.GetAllTaskByUserAsync(userId);

        return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
    }
}
