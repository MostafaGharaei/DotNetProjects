using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyDemo;

/// <summary>
/// Shopping cart that uses payment strategies
/// </summary>
public class ShoppingCart
{
    private readonly List<CartItem> _items = [];
    private IPaymentStrategy? _paymentStrategy;

    public void AddItem(string name, decimal price, int quantity = 1)
    {
        var item = new CartItem(name, price, quantity);
        _items.Add(item);
        Console.WriteLine($"➕ Added {quantity}x {name} to cart (${price:F2} each)");
    }

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
        Console.WriteLine($"💳 Payment method changed to: {strategy.Name}");
    }

    public decimal CalculateTotal() => _items.Sum(item => item.Price * item.Quantity);

    public bool IsEmpty => _items.Count == 0;

    public int ItemCount => _items.Count;

    public void Checkout()
    {
        if (_paymentStrategy is null)
            throw new InvalidOperationException("Please select a payment method first!");

        if (IsEmpty)
            throw new InvalidOperationException("Cart is empty!");

        var total = CalculateTotal();
        Console.WriteLine($"\n📋 Cart Summary:");
        Console.WriteLine($"   Total items: {ItemCount}");
        Console.WriteLine($"   Total amount: ${total:F2}");
        Console.WriteLine($"   Payment method: {_paymentStrategy.Name}");
        Console.WriteLine();

        _paymentStrategy.Pay(total);

        Console.WriteLine($"\n✅ Order completed successfully at {DateTime.Now:HH:mm:ss}");
        _items.Clear();
    }

    public void DisplayCart()
    {
        if (IsEmpty)
        {
            Console.WriteLine("🛒 Cart is empty");
            return;
        }

        Console.WriteLine("\n🛒 Cart Contents:");
        foreach (var item in _items)
        {
            Console.WriteLine($"   {item.Quantity}x {item.Name} - ${item.Price:F2} each (${item.Price * item.Quantity:F2})");
        }
        Console.WriteLine($"   Total: ${CalculateTotal():F2}");
    }
}

/// <summary>
/// Cart item record (immutable)
/// </summary>
public record CartItem(string Name, decimal Price, int Quantity);