namespace TaskManagement.Domain.Entities
{
    // Represents a task in the system
    public class TaskItem
    {
        public int Id { get; set; }

        // Title of the task
        public string Title { get; set; }

        // Optional description
        public string Description { get; set; }

        // Indicates whether the task is completed
        public bool IsCompleted { get; set; }
    }
}
