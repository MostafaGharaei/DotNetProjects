using System;

namespace FactoryDemo;

/// <summary>
/// Factory class for creating notification instances
/// </summary>
public static class NotificationFactory
{
    /// <summary>
    /// Creates a notification instance based on the specified type
    /// </summary>
    public static INotification Create(string type) => type.ToLowerInvariant() switch
    {
        "email" => new EmailNotification(),
        "sms" => new SMSNotification(),
        "push" => new PushNotification(),
        _ => throw new ArgumentException($"Unsupported notification type: {type}", nameof(type))
    };

    /// <summary>
    /// Creates a notification with validation
    /// </summary>
    public static bool TryCreate(string type, out INotification? notification)
    {
        try
        {
            notification = Create(type);
            return true;
        }
        catch
        {
            notification = null;
            return false;
        }
    }
}