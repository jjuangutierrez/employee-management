using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class GetTaskUseCase
{
    private readonly ITaskService _taskService;

    public GetTaskUseCase(ITaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    public async Task<TaskResponseDto> ExecuteAsync(int taskId)
    {
        if (taskId <= 0)
            throw new ArgumentException("Task ID must be greater than zero", nameof(taskId));

        var task = await _taskService.GetTaskAsync(taskId);

        return new TaskResponseDto
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            Status = task.Status,
            CreateAt = task.CreateAt,
            UpdateAt = task.UpdateAt,
            UserId = task.UserId,
            UserName = task.User != null
                ? $"{task.User.FirstName} {task.User.LastName}".Trim()
                : string.Empty
        };
    }
}
