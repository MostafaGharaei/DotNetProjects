using System;

namespace FactoryDemo;

/// <summary>
/// SMS notification implementation
/// </summary>
public sealed class SMSNotification : INotification
{
    public string TypeName => "SMS";

    public void Send(string recipient, string message)
    {
        Console.WriteLine($"📱 Sending SMS to {recipient}");
        Console.WriteLine($"📝 Message: {message}");
        Console.WriteLine($"✅ SMS sent successfully at {DateTime.Now:HH:mm:ss}");
    }
}