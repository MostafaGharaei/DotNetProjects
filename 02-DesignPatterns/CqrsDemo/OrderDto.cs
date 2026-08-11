using System;

namespace CqrsDemo;

public sealed record OrderDto(Guid Id, string ProductName, int Quantity, decimal TotalAmount);