using System;

namespace FactoryDemo;

/// <summary>
/// Email notification implementation
/// </summary>
public sealed class EmailNotification : INotification
{
    public string TypeName => "Email";

    public void Send(string recipient, string message)
    {
        Console.WriteLine($"📧 Sending EMAIL to {recipient}");
        Console.WriteLine($"📝 Message: {message}");
        Console.WriteLine($"✅ Email sent successfully at {DateTime.Now:HH:mm:ss}");
    }
}