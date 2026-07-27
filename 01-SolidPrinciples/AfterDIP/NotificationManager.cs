using System;

namespace AfterDIP
{
    /// <summary>
    /// Notification manager that depends on abstraction
    /// This follows DIP - depends on INotificationService interface
    /// </summary>
    public class NotificationManager
    {
        private readonly INotificationService _notificationService;

        /// <summary>
        /// Initializes a new instance of the NotificationManager class
        /// </summary>
        /// <param name="notificationService">The notification service to use</param>
        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        /// <summary>
        /// Sends a notification using the injected service
        /// </summary>
        /// <param name="recipient">The recipient of the notification</param>
        /// <param name="message">The message to send</param>
        public void SendNotification(string recipient, string message)
        {
            if (string.IsNullOrEmpty(recipient))
                throw new ArgumentException("Recipient cannot be empty", nameof(recipient));

            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            _notificationService.Send(recipient, message);
        }
    }
}