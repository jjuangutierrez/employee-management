using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class UpdateTaskUseCase
{
    private readonly ITaskService _taskService;

    public UpdateTaskUseCase(ITaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    public async Task<TaskResponseDto> ExecuteAsync(int taskId, UpdateTaskDto updateTaskDto)
    {
        if (taskId <= 0)
            throw new ArgumentException("Task ID must be greater than zero", nameof(taskId));

        if (updateTaskDto == null)
            throw new ArgumentNullException(nameof(updateTaskDto));

        var existingTask = await _taskService.GetTaskAsync(taskId);

        if (updateTaskDto.Name != null)
            existingTask.Name = updateTaskDto.Name.Trim();

        if (updateTaskDto.Description != null)
            existingTask.Description = updateTaskDto.Description.Trim();

        if (updateTaskDto.Status.HasValue)
            existingTask.Status = updateTaskDto.Status.Value;

        existingTask.UpdateAt = DateTime.UtcNow;

        var updatedTask = await _taskService.UpdateTaskAsync(existingTask);

        return new TaskResponseDto
        {
            Id = updatedTask.Id,
            Name = updatedTask.Name,
            Description = updatedTask.Description,
            Status = updatedTask.Status,
            CreateAt = updatedTask.CreateAt,
            UpdateAt = updatedTask.UpdateAt,
            UserId = updatedTask.UserId,
            UserName = updatedTask.User != null
                ? $"{updatedTask.User.FirstName} {updatedTask.User.LastName}".Trim()
                : string.Empty
        };
    }
}
