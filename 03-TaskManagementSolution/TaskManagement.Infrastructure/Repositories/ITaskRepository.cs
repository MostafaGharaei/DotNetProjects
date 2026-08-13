using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Repositories
{
    // Repository interface for TaskItem
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(int id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);
    }
}
