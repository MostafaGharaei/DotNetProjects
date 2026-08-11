using System;

namespace CqrsDemo;

public sealed record GetOrderQuery(Guid OrderId) : IQuery<OrderDto?>;