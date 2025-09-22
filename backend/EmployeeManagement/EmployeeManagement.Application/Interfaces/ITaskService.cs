using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskEntity>> GetAllTaskByUserAsync(int userId);
    Task<TaskEntity> GetTaskByUserAsync(int userId);
    Task<TaskEntity> GetTaskAsync(int taksId);
    Task<TaskEntity> InsertTaskAsync(int userId, TaskEntity taskDto);
    Task<TaskEntity> UpdateTaskAsync(TaskEntity taskEntity);
    Task<TaskEntity> DeleteTaskAsync(int taskId);
}
