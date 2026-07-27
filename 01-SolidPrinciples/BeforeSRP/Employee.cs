using System;

namespace BeforeSRP
{
    /// <summary>
    /// Represents an employee in the system
    /// This class violates SRP by handling multiple responsibilities
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the employee
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the monthly salary of the employee
        /// </summary>
        public decimal MonthlySalary { get; set; }

        /// <summary>
        /// Initializes a new instance of the Employee class
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="name">Employee name</param>
        /// <param name="email">Employee email</param>
        /// <param name="monthlySalary">Employee monthly salary</param>
        public Employee(int id, string name, string email, decimal monthlySalary)
        {
            Id = id;
            Name = name;
            Email = email;
            MonthlySalary = monthlySalary;
        }

        /// <summary>
        /// Calculates the annual salary of the employee
        /// </summary>
        /// <returns>The annual salary (monthly salary * 12)</returns>
        public decimal CalculateAnnualSalary()
        {
            return MonthlySalary * 12;
        }

        /// <summary>
        /// Saves the employee to the database
        /// This method violates SRP by mixing business logic with persistence logic
        /// </summary>
        public void SaveToDatabase()
        {
            // Simulate database save operation
            Console.WriteLine($"Saving employee {Name} to database...");
            // In real implementation: INSERT INTO Employees...
            Console.WriteLine($"Employee {Name} saved successfully!");
        }

        /// <summary>
        /// Sends a welcome email to the employee
        /// This method violates SRP by mixing business logic with email logic
        /// </summary>
        public void SendWelcomeEmail()
        {
            // Simulate email sending
            Console.WriteLine($"Sending welcome email to {Email}...");
            // In real implementation: SMTP client send...
            Console.WriteLine($"Welcome email sent to {Name}!");
        }

        /// <summary>
        /// Generates a formatted report for the employee
        /// This method violates SRP by mixing business logic with report generation
        /// </summary>
        /// <returns>Formatted employee information string</returns>
        public string GenerateEmployeeReport()
        {
            return $"Employee Report:\n" +
                   $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Email: {Email}\n" +
                   $"Monthly Salary: {MonthlySalary:C}\n" +
                   $"Annual Salary: {CalculateAnnualSalary():C}";
        }
    }
}