using System;

namespace CqrsDemo;

public sealed record CreateOrderCommand(string ProductName, int Quantity, decimal Price) : ICommand<Guid>;