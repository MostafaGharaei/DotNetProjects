namespace DecoratorDemo;

/// <summary>
/// Base decorator class that wraps an INotificationService
/// </summary>
public abstract class NotificationServiceDecorator(INotificationService inner) : INotificationService
{
    protected readonly INotificationService _inner = inner;

    public abstract void Send(string recipient, string message);
}