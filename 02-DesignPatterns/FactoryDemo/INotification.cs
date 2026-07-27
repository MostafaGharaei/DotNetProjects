namespace FactoryDemo;

/// <summary>
/// Interface for all notification types
/// </summary>
public interface INotification
{
    void Send(string recipient, string message);
    string TypeName { get; }
}