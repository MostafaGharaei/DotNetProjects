using MediatR;
using TaskManagement.Application.Tasks.Strategies;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Application.Tasks.Queries
{
    public class GetSortedTasksQueryHandler
        : IRequestHandler<GetSortedTasksQuery, List<TaskItem>>
    {
        private readonly ITaskRepository _repo;

        public GetSortedTasksQueryHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TaskItem>> Handle(GetSortedTasksQuery request, CancellationToken ct)
        {
            var tasks = await _repo.GetAllAsync();

            ITaskSortingStrategy strategy = request.SortType switch
            {
                "title" => new SortByTitleStrategy(),
                "status" => new SortByStatusStrategy(),
                _ => new SortByTitleStrategy()
            };

            return strategy.Sort(tasks);
        }
    }
}
