using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskEntity>> GetAllTaskByUserAsync(int userId);
    Task<TaskEntity?> GetTaskAsync(int id);
    Task<TaskEntity?> GetTaskByUserAsync(int userId);
    Task<TaskEntity> InsertTaskAsync(TaskEntity taskDto);
    Task UpdateTaskAsync(TaskEntity taskEntity);
    Task DeleteTaskAsync(int taskId);
}
