using System;

namespace UnitOfWorkDemo;

/// <summary>
/// Product entity
/// </summary>
public record Product
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
    public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
    public string? Category { get; init; }
    public string? SKU { get; init; }

    public bool IsAvailable => StockQuantity > 0;

    public override string ToString()
        => $"[{Id}] {Name} - ${Price:F2} (Stock: {StockQuantity}) {(IsAvailable ? "✅" : "❌")}";
}