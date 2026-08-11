using System;

namespace DecoratorDemo;

/// <summary>
/// Decorator that adds logging functionality
/// </summary>
public sealed class LoggingNotificationDecorator(INotificationService inner) : NotificationServiceDecorator(inner)
{
    public override void Send(string recipient, string message)
    {
        Console.WriteLine($"📝 [LOG] Sending notification to {recipient} at {DateTime.Now}");
        _inner.Send(recipient, message);
        Console.WriteLine($"📝 [LOG] Notification sent successfully");
    }
}