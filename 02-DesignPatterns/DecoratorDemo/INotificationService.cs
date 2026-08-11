namespace DecoratorDemo;

/// <summary>
/// Core interface for notification services
/// </summary>
public interface INotificationService
{
    void Send(string recipient, string message);
}