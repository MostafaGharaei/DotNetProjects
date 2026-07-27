namespace StrategyDemo;

/// <summary>
/// Strategy interface for payment methods
/// </summary>
public interface IPaymentStrategy
{
    void Pay(decimal amount);
    string Name { get; }
}