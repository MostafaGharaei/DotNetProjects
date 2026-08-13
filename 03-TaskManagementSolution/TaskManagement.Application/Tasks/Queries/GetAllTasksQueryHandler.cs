using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Application.Tasks.Queries
{
    // Handles GetAllTasksQuery
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
    {
        private readonly ITaskRepository _repo;

        public GetAllTasksQueryHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken ct)
        {
            return await _repo.GetAllAsync();
        }
    }
}
