using System;

namespace AfterDIP
{
    /// <summary>
    /// Email notification service implementation
    /// This follows DIP - implements abstraction
    /// </summary>
    public class EmailService : INotificationService
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"Sending email to {recipient}: {message}");
        }
    }
}