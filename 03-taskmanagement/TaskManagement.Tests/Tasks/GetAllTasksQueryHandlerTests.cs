using Moq;
using TaskManagement.Application.Tasks.Queries;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Tests.Tasks
{
    public class GetAllTasksQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnAllTasks()
        {
            // Arrange: create fake repository
            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<TaskItem>
                {
                    new TaskItem { Id = 1, Title = "Test 1" },
                    new TaskItem { Id = 2, Title = "Test 2" }
                });

            // Create handler
            var handler = new GetAllTasksQueryHandler(mockRepo.Object);

            // Act: execute handler
            var result = await handler.Handle(new GetAllTasksQuery(), CancellationToken.None);

            // Assert: verify result
            Assert.Equal(2, result.Count);
            Assert.Equal("Test 1", result[0].Title);
        }
    }
}
