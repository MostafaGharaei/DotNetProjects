using MediatR;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Application.Tasks.Commands
{
    // Handles DeleteTaskCommand
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskRepository _repo;

        public DeleteTaskCommandHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken ct)
        {
            var existing = await _repo.GetByIdAsync(request.Id);

            if (existing == null)
                return false;

            await _repo.DeleteAsync(request.Id);
            return true;
        }
    }
}
