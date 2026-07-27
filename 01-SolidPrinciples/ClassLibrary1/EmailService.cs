using System;

namespace AfterSRP
{
    /// <summary>
    /// Responsible for email-related operations
    /// This class follows SRP by handling only email functionality
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Sends a welcome email to an employee
        /// </summary>
        /// <param name="employee">The employee to send email to</param>
        public void SendWelcomeEmail(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            Console.WriteLine($"Sending welcome email to {employee.Email}...");
            // Simulate email sending logic
            Console.WriteLine($"Welcome email sent to {employee.Name}!");
        }

        /// <summary>
        /// Sends a notification email to an employee
        /// </summary>
        /// <param name="employee">The employee to send email to</param>
        /// <param name="subject">Email subject</param>
        /// <param name="message">Email message</param>
        public void SendNotification(Employee employee, string subject, string message)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (string.IsNullOrEmpty(subject))
                throw new ArgumentException("Subject cannot be empty", nameof(subject));

            Console.WriteLine($"Sending notification to {employee.Email}...");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Notification sent to {employee.Name}!");
        }
    }
}