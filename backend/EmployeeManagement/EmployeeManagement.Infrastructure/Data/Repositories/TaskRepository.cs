using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext appDbContext) => _context = appDbContext;

    public async Task<TaskEntity?> GetTaskAsync(int taskId)
    {
        return await _context.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == taskId);
    }

    public async Task<TaskEntity?> GetTaskByUserAsync(int userId)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.UserId == userId);

        return task;
    }

    public async Task<IEnumerable<TaskEntity>> GetAllTaskByUserAsync(int userId)
    {
        var tasks = await _context.Tasks
            .Include(t => t.User)
            .Where(t => t.UserId == userId)
            .ToListAsync();

        return tasks;
    }



    public async Task<TaskEntity> InsertTaskAsync(TaskEntity taskEntity)
    {
        taskEntity.CreateAt = DateTime.UtcNow;
        taskEntity.UpdateAt = DateTime.UtcNow;

        await _context.AddAsync(taskEntity);
        await _context.SaveChangesAsync();

        return taskEntity;
    }

    public async Task UpdateTaskAsync(TaskEntity taskEntity)
    {
        var existingTask = await _context.Tasks.FindAsync(taskEntity.Id);

        if (existingTask == null)
            throw new KeyNotFoundException($"Task with ID {taskEntity.Id} not found");

        existingTask.Name = taskEntity.Name;
        existingTask.Description = taskEntity.Description;
        existingTask.Status = taskEntity.Status;
        existingTask.UpdateAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var task = await _context.Tasks.FindAsync(taskId);

        if (task == null)
            throw new Exception("Task not found or not owned by this user");

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}
