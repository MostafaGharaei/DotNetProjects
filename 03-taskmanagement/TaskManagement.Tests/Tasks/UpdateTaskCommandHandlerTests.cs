using Moq;
using TaskManagement.Application.Tasks.Commands;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Tests.Tasks
{
    public class UpdateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldUpdateExistingTask()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();

            var existingTask = new TaskItem
            {
                Id = 1,
                Title = "Old Title",
                Description = "Old Desc",
                IsCompleted = false
            };

            mockRepo.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(existingTask);

            mockRepo.Setup(r => r.UpdateAsync(existingTask))
                .Returns(Task.CompletedTask);

            var handler = new UpdateTaskCommandHandler(mockRepo.Object);

            var command = new UpdateTaskCommand(1, "New Title", "New Desc", true);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("New Title", result.Title);
            Assert.True(result.IsCompleted);
        }
    }
}
