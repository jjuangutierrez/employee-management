using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository) => _taskRepository = taskRepository;

    public async Task<TaskEntity> DeleteTaskAsync(int taskId)
    {
        if (taskId <= 0) throw new ArgumentException("Invalid task ID", nameof(taskId));

        var task = await _taskRepository.GetTaskAsync(taskId);

        if (task == null)
            throw new KeyNotFoundException("Task not found or not owned by this user");

        await _taskRepository.DeleteTaskAsync(taskId);
        return task;
    }



    public async Task<IEnumerable<TaskEntity>> GetAllTaskByUserAsync(int userId)
    { 
        var tasks = await _taskRepository.GetAllTaskByUserAsync(userId);

        return tasks;
    }

    public async Task<TaskEntity> GetTaskAsync(int taskId)
    {
        var task = await _taskRepository.GetTaskAsync(taskId);

        if (task == null)
            throw new KeyNotFoundException($"task: {taskId} not found");

        return task;
    }

    public async Task<TaskEntity> GetTaskByUserAsync(int userId)
    {
        var taskByUser = await _taskRepository.GetTaskByUserAsync(userId);

        if (taskByUser == null)
            throw new KeyNotFoundException($"task in user {userId} not found");

        return taskByUser;
    }

    public async Task<TaskEntity> InsertTaskAsync(int userId, TaskEntity taskEntity)
    {
        if (userId <= 0) throw new ArgumentException("Invalid user ID", nameof(userId));
        if (taskEntity == null) throw new ArgumentNullException(nameof(taskEntity));
        if (string.IsNullOrWhiteSpace(taskEntity.Name))
            throw new ArgumentException("The name is required", nameof(userId));

        taskEntity.UserId = userId;

        return await _taskRepository.InsertTaskAsync(taskEntity);
    }

    public async Task<TaskEntity> UpdateTaskAsync(TaskEntity taskEntity)
    {
        if (taskEntity == null) throw new ArgumentNullException(nameof(taskEntity));
        if (taskEntity.Id <= 0) throw new ArgumentException("Invalid task ID", nameof(taskEntity));

        var existingTask = await _taskRepository.GetTaskAsync(taskEntity.Id);

        await _taskRepository.UpdateTaskAsync(taskEntity);
        return taskEntity;
    }
}
