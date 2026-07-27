using System;

namespace BeforeDIP
{
    /// <summary>
    /// Email service implementation
    /// </summary>
    public class EmailService
    {
        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"Sending email to {to}: {message}");
        }
    }

    /// <summary>
    /// SMSService implementation
    /// </summary>
    public class SMSService
    {
        public void SendSMS(string phoneNumber, string message)
        {
            Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
        }
    }

    /// <summary>
    /// Notification service that violates DIP
    /// Depends on concrete implementations instead of abstractions
    /// </summary>
    public class NotificationService
    {
        private readonly EmailService _emailService;
        private readonly SMSService _smsService;

        public NotificationService()
        {
            _emailService = new EmailService();
            _smsService = new SMSService();
        }

        public void SendNotification(string to, string message, string type)
        {
            if (type == "Email")
            {
                _emailService.SendEmail(to, message);
            }
            else if (type == "SMS")
            {
                _smsService.SendSMS(to, message);
            }
            else
            {
                throw new ArgumentException("Invalid notification type");
            }
        }
    }
}