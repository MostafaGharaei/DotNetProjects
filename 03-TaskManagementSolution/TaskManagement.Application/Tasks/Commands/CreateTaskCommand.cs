using MediatR;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Tasks.Commands
{
    // Command to create a new task
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItem>;
}
