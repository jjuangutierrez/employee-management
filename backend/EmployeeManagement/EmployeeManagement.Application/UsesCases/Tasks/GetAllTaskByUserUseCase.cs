using AutoMapper;
using EmployeeManagement.Application.DTOs.Tasks;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.UsesCases.Tasks;

public class GetAllTaskByUserUseCase
{
    private readonly ITaskService _taskService;

    public GetAllTaskByUserUseCase(ITaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    public async Task<IEnumerable<TaskResponseDto>> ExecuteAsync(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("User ID must be greater than zero", nameof(userId));

        var tasks = await _taskService.GetAllTaskByUserAsync(userId);

        return tasks.Select(task => new TaskResponseDto
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
        });
    }
}