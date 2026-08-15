using Moq;
using TaskManagement.Application.Tasks.Commands;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Tests.Tasks
{
    public class CreateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateNewTask()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(r => r.AddAsync(It.IsAny<TaskItem>()))
                .Returns(Task.CompletedTask);

            var handler = new CreateTaskCommandHandler(mockRepo.Object);

            var command = new CreateTaskCommand("New Task", "Description");

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("New Task", result.Title);
            Assert.False(result.IsCompleted);
        }
    }
}
