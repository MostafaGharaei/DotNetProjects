using System;

namespace AfterSRP
{
    /// <summary>
    /// Represents an employee in the system
    /// This class follows SRP by handling only employee data representation
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
    }
}