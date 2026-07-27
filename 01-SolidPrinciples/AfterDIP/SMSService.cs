using System;

namespace AfterDIP
{
    /// <summary>
    /// SMS notification service implementation
    /// This follows DIP - implements abstraction
    /// </summary>
    public class SMSService : INotificationService
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
        }
    }
}