using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class CreateTaskUseCase
{
    private readonly ITaskService _taskService;

    public CreateTaskUseCase(ITaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    public async Task<TaskResponseDto> ExecuteAsync(int userId, CreateTaskDto createTaskDto)
    {
        if (userId <= 0)
            throw new ArgumentException("User ID must be greater than zero", nameof(userId));

        if (createTaskDto == null)
            throw new ArgumentNullException(nameof(createTaskDto));

        var taskEntity = new TaskEntity
        {
            Name = createTaskDto.Name?.Trim() ?? string.Empty,
            Description = createTaskDto.Description?.Trim() ?? string.Empty,
            Status = createTaskDto.Status,
            UserId = userId
        };

        var createdTask = await _taskService.InsertTaskAsync(userId, taskEntity);

        return new TaskResponseDto
        {
            Id = createdTask.Id,
            Name = createdTask.Name,
            Description = createdTask.Description,
            Status = createdTask.Status,
            CreateAt = createdTask.CreateAt,
            UpdateAt = createdTask.UpdateAt,
            UserId = createdTask.UserId,
            UserName = createdTask.User != null
                ? $"{createdTask.User.FirstName} {createdTask.User.LastName}".Trim()
                : string.Empty
        };
    }
}

