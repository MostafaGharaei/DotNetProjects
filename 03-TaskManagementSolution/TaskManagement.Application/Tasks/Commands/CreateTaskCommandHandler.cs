using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Application.Tasks.Commands
{
    // Handles CreateTaskCommand
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskItem>
    {
        private readonly ITaskRepository _repo;

        public CreateTaskCommandHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<TaskItem> Handle(CreateTaskCommand request, CancellationToken ct)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            await _repo.AddAsync(task);
            return task;
        }
    }
}
