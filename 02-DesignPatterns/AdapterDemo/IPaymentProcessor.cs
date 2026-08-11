using System.Threading.Tasks;

namespace AdapterDemo;

/// <summary>
/// Target interface expected by the system
/// </summary>
public interface IPaymentProcessor
{
    Task<PaymentResult> ProcessPaymentAsync(decimal amount, string currency, string customerId);
}