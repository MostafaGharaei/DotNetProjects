namespace AfterDIP
{
    /// <summary>
    /// Interface for notification services
    /// This follows DIP - abstraction that both high-level and low-level modules depend on
    /// </summary>
    public interface INotificationService
    {
        void Send(string recipient, string message);
    }
}