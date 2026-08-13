using MediatR;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Tasks.Commands
{
    // Command to update an existing task
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted)
        : IRequest<TaskItem>;
}
