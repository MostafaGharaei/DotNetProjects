using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Tasks.Strategies
{
    // Sort tasks by completion status
    public class SortByStatusStrategy : ITaskSortingStrategy
    {
        public List<TaskItem> Sort(List<TaskItem> tasks)
        {
            return tasks.OrderBy(t => t.IsCompleted).ToList();
        }
    }
}
