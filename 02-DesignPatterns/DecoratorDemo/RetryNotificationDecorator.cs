using System;
using System.Threading;

namespace DecoratorDemo;

/// <summary>
/// Decorator that adds retry functionality
/// </summary>
public sealed class RetryNotificationDecorator(INotificationService inner, int maxRetries = 3) : NotificationServiceDecorator(inner)
{
    public override void Send(string recipient, string message)
    {
        int attempt = 0;
        while (true)
        {
            try
            {
                _inner.Send(recipient, message);
                return;
            }
            catch (Exception ex) when (attempt < maxRetries - 1)
            {
                attempt++;
                Console.WriteLine($"⚠️ [RETRY] Attempt {attempt} failed: {ex.Message}. Retrying...");
                Thread.Sleep(1000 * attempt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [RETRY] All {maxRetries} attempts failed: {ex.Message}");
                throw;
            }
        }
    }
}