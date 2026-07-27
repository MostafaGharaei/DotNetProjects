using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitOfWorkDemo;

/// <summary>
/// Order entity
/// </summary>
public record Order
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public DateTime OrderDate { get; init; } = DateTime.UtcNow;
    public decimal TotalAmount { get; init; }
    public required string Status { get; init; }
    public required List<OrderItem> Items { get; init; }
    public string? ShippingAddress { get; init; }
    public string? PaymentMethod { get; init; }

    public int ItemCount => Items?.Count ?? 0;
    public bool IsCompleted => Status == "Delivered" || Status == "Completed";
    public bool IsPending => Status == "Pending";

    public override string ToString()
        => $"Order #{Id} - {Status} - ${TotalAmount:F2} ({OrderDate:yyyy-MM-dd HH:mm}) - {ItemCount} items";
}

/// <summary>
/// Order item record
/// </summary>
public record OrderItem
{
    public int ProductId { get; init; }
    public required string ProductName { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal TotalPrice => UnitPrice * Quantity;
}