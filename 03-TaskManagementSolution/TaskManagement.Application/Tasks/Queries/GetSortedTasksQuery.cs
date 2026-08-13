using MediatR;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Tasks.Queries
{
    // Query to get sorted tasks using a strategy
    public record GetSortedTasksQuery(string SortType) : IRequest<List<TaskItem>>;
}
