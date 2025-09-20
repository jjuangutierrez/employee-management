using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class UpdateTaskUseCase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public UpdateTaskUseCase(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    public async Task<TaskResponseDto> ExecuteAsync(int id, UpdateTaskDto dto)
    {
        var existingTask = await _taskService.GetTaskAsync(id);
        if (existingTask == null)
            throw new KeyNotFoundException($"Task {id} not found");

        _mapper.Map(dto, existingTask);
        existingTask.UpdateAt = DateTime.UtcNow;

        var updatedTask = await _taskService.UpdateTaskAsync(existingTask);

        return _mapper.Map<TaskResponseDto>(updatedTask);
    }
}
