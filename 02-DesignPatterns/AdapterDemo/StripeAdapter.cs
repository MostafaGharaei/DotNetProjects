using System.Threading.Tasks;

namespace AdapterDemo;

/// <summary>
/// Adapter that makes StripeApi compatible with IPaymentProcessor
/// </summary>
public sealed class StripeAdapter(StripeApi stripeApi) : IPaymentProcessor
{
    public async Task<PaymentResult> ProcessPaymentAsync(decimal amount, string currency, string customerId)
    {
        var request = new StripeChargeRequest(
            (long)(amount * 100),
            currency.ToUpper(),
            customerId
        );

        var result = await stripeApi.CreateChargeAsync(request);
        return new PaymentResult(
            result.ChargeId,
            result.Status == "succeeded",
            result.Status == "succeeded" ? "Payment successful" : "Payment failed"
        );
    }
}