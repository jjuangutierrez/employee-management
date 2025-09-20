using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class DeleteTaskUseCase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public DeleteTaskUseCase(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    public async Task<TaskResponseDto> ExecuteAsync(int taskId)
    {
        if (taskId <= 0)
            throw new ArgumentException("task ID must be greater than zero", nameof(taskId));

        var deletedTask = await _taskService.DeleteTaskAsync(taskId);

        return _mapper.Map<TaskResponseDto>(deletedTask);
    }
}
