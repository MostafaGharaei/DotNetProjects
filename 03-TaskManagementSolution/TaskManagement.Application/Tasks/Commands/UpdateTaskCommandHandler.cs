using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Application.Tasks.Commands
{
    // Handles UpdateTaskCommand
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskItem>
    {
        private readonly ITaskRepository _repo;

        public UpdateTaskCommandHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<TaskItem> Handle(UpdateTaskCommand request, CancellationToken ct)
        {
            // Fetch existing task
            var existing = await _repo.GetByIdAsync(request.Id);

            if (existing == null)
                return null;

            // Update fields
            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.IsCompleted = request.IsCompleted;

            await _repo.UpdateAsync(existing);

            return existing;
        }
    }
}
