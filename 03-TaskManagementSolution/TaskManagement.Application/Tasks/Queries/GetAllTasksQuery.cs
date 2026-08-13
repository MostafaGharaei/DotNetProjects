using MediatR;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Tasks.Queries
{
    // Query to get all tasks
    public record GetAllTasksQuery() : IRequest<List<TaskItem>>;
}
