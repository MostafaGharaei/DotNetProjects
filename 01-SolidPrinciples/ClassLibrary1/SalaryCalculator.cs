using System;

namespace AfterSRP
{
    /// <summary>
    /// Responsible for salary-related calculations
    /// This class follows SRP by handling only salary calculation logic
    /// </summary>
    public class SalaryCalculator
    {
        /// <summary>
        /// Calculates the annual salary for an employee
        /// </summary>
        /// <param name="employee">The employee to calculate salary for</param>
        /// <returns>The annual salary (monthly salary * 12)</returns>
        public decimal CalculateAnnualSalary(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            return employee.MonthlySalary * 12;
        }

        /// <summary>
        /// Calculates the bonus for an employee based on performance
        /// </summary>
        /// <param name="employee">The employee to calculate bonus for</param>
        /// <param name="performanceRating">Performance rating (1-5)</param>
        /// <returns>The bonus amount</returns>
        public decimal CalculateBonus(Employee employee, int performanceRating)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (performanceRating < 1 || performanceRating > 5)
                throw new ArgumentOutOfRangeException(nameof(performanceRating), "Rating must be between 1 and 5");

            // 10% bonus for each rating point above 3
            decimal bonusPercentage = (performanceRating - 3) * 0.10m;
            return employee.MonthlySalary * Math.Max(0, bonusPercentage);
        }
    }
}