using System;

namespace StrategyDemo;

/// <summary>
/// Credit card payment strategy using Primary Constructor
/// </summary>
public sealed class CreditCardPayment(string cardNumber, string cardHolder) : IPaymentStrategy
{
    public string Name => "Credit Card";

    public void Pay(decimal amount)
    {
        Console.WriteLine($"💳 Paying ${amount:F2} using Credit Card");
        Console.WriteLine($"   Card: ****{cardNumber[^4..]}");
        Console.WriteLine($"   Holder: {cardHolder}");
        Console.WriteLine("✅ Payment processed successfully!");
    }
}

/// <summary>
/// PayPal payment strategy
/// </summary>
public sealed class PayPalPayment(string email) : IPaymentStrategy
{
    public string Name => "PayPal";

    public void Pay(decimal amount)
    {
        Console.WriteLine($"💰 Paying ${amount:F2} using PayPal");
        Console.WriteLine($"   Account: {email}");
        Console.WriteLine("✅ Payment processed successfully!");
    }
}

/// <summary>
/// Bitcoin payment strategy
/// </summary>
public sealed class BitcoinPayment(string walletAddress) : IPaymentStrategy
{
    public string Name => "Bitcoin";

    public void Pay(decimal amount)
    {
        Console.WriteLine($"₿ Paying ${amount:F2} using Bitcoin");
        Console.WriteLine($"   Wallet: {walletAddress[..8]}...{walletAddress[^6..]}");
        Console.WriteLine("✅ Payment processed successfully!");
    }
}

/// <summary>
/// Cash payment strategy
/// </summary>
public sealed class CashPayment : IPaymentStrategy
{
    public string Name => "Cash";

    public void Pay(decimal amount)
    {
        Console.WriteLine($"💵 Paying ${amount:F2} in Cash");
        Console.WriteLine("✅ Payment processed successfully!");
    }
}