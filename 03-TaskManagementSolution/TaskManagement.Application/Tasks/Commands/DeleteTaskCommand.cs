using MediatR;

namespace TaskManagement.Application.Tasks.Commands
{
    // Command to delete a task by Id
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
