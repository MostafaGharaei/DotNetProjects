using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Tasks.Strategies
{
    // Strategy interface for sorting tasks
    public interface ITaskSortingStrategy
    {
        List<TaskItem> Sort(List<TaskItem> tasks);
    }
}
