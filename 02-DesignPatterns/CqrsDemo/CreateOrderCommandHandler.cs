using System;
using System.Threading.Tasks;

namespace CqrsDemo;

public sealed class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Guid>
{
    public Task<Guid> Handle(CreateOrderCommand command)
    {
        var orderId = Guid.NewGuid();
        Console.WriteLine($"📝 [CQRS Command] Order created: {orderId} for {command.ProductName} x {command.Quantity}");
        return Task.FromResult(orderId);
    }
}