using Moq;
using TaskManagement.Application.Tasks.Commands;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Tests.Tasks
{
    public class DeleteTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldDeleteTask_WhenExists()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new TaskItem { Id = 1 });

            mockRepo.Setup(r => r.DeleteAsync(1))
                .Returns(Task.CompletedTask);

            var handler = new DeleteTaskCommandHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(new DeleteTaskCommand(1), CancellationToken.None);

            // Assert
            Assert.True(result);
        }
    }
}
