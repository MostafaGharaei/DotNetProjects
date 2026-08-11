using System;
using System.Threading.Tasks;

namespace CqrsDemo;

public sealed class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderDto?>
{
    public Task<OrderDto?> Handle(GetOrderQuery query)
    {
        if (query.OrderId == Guid.Empty)
            return Task.FromResult<OrderDto?>(null);

        // ✅ تغییر از TotalPrice به TotalAmount
        var order = new OrderDto(query.OrderId, "Sample Product", 2, 199.98m);
        Console.WriteLine($"📖 [CQRS Query] Order retrieved: {order.Id}");
        return Task.FromResult<OrderDto?>(order);
    }
}