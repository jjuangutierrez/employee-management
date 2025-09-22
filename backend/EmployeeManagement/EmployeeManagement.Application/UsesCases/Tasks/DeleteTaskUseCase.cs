using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class DeleteTaskUseCase
{
    private readonly ITaskService _taskService;

    public DeleteTaskUseCase(ITaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    public async Task<TaskResponseDto> ExecuteAsync(int taskId)
    {
        if (taskId <= 0)
            throw new ArgumentException("Task ID must be greater than zero", nameof(taskId));

        var deletedTask = await _taskService.DeleteTaskAsync(taskId);

        return new TaskResponseDto
        {
            Id = deletedTask.Id,
            Name = deletedTask.Name,
            Description = deletedTask.Description,
            Status = deletedTask.Status,
            CreateAt = deletedTask.CreateAt,
            UpdateAt = deletedTask.UpdateAt,
            UserId = deletedTask.UserId,
            UserName = deletedTask.User != null
                ? $"{deletedTask.User.FirstName} {deletedTask.User.LastName}".Trim()
                : string.Empty
        };
    }
}

