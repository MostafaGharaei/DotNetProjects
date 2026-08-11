using System;

namespace DecoratorDemo;

/// <summary>
/// Concrete implementation of email notification
/// </summary>
public sealed class EmailNotificationService : INotificationService
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"📧 Sending EMAIL to {recipient}: {message}");
        // Simulate email sending
        Console.WriteLine($"✅ Email sent successfully at {DateTime.Now:HH:mm:ss}");
    }
}