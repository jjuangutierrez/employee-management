using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class CreateTaskUseCase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public CreateTaskUseCase(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    public async Task<TaskResponseDto> ExecuteAsync(int userId, CreateTaskDto task)
    {
        var taskEntity = _mapper.Map<TaskEntity>(task);
        taskEntity.UserId = userId;

        var createTask = await _taskService.InsertTaskAsync(userId, taskEntity);

        return _mapper.Map<TaskResponseDto>(createTask);

    }
}
