using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Tasks.Strategies
{
    // Sort tasks alphabetically by title
    public class SortByTitleStrategy : ITaskSortingStrategy
    {
        public List<TaskItem> Sort(List<TaskItem> tasks)
        {
            return tasks.OrderBy(t => t.Title).ToList();
        }
    }
}
