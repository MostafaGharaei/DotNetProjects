using System;

namespace AfterDIP
{
    /// <summary>
    /// Push notification service implementation
    /// This follows DIP - implements abstraction
    /// </summary>
    public class PushNotificationService : INotificationService
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"Sending push notification to {recipient}: {message}");
        }
    }
}