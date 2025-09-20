using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.DTOs.UserWithEmployee;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class GetTaskUseCase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public GetTaskUseCase(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    public async Task<TaskResponseDto> ExecuteAsync(int taskId)
    {
        if (taskId <= 0)
            throw new ArgumentException("Task ID must be greater than zero", nameof(taskId));

        var user = await _taskService.GetTaskAsync(taskId);

        return _mapper.Map<TaskResponseDto>(user);
    }
}
