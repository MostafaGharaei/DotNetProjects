using System;
using System.Threading.Tasks;

namespace AdapterDemo;

/// <summary>
/// Third-party Stripe API (incompatible interface)
/// </summary>
public sealed class StripeApi
{
    public Task<StripeChargeResult> CreateChargeAsync(StripeChargeRequest request)
    {
        // Simulate processing
        return Task.FromResult(new StripeChargeResult(
            $"ch_{Guid.NewGuid():N}",
            "succeeded",
            request.AmountInCents
        ));
    }
}

public sealed record StripeChargeRequest(long AmountInCents, string CurrencyCode, string CustomerId);
public sealed record StripeChargeResult(string ChargeId, string Status, long AmountCaptured);