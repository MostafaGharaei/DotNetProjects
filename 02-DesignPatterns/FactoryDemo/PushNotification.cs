using System;

namespace FactoryDemo;

/// <summary>
/// Push notification implementation
/// </summary>
public sealed class PushNotification : INotification
{
    public string TypeName => "Push";

    public void Send(string recipient, string message)
    {
        Console.WriteLine($"🔔 Sending PUSH notification to {recipient}");
        Console.WriteLine($"📝 Message: {message}");
        Console.WriteLine($"✅ Push notification sent successfully at {DateTime.Now:HH:mm:ss}");
    }
}