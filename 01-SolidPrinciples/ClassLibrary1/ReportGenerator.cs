using System;
using System.Text;

namespace AfterSRP
{
    /// <summary>
    /// Responsible for generating reports
    /// This class follows SRP by handling only report generation
    /// </summary>
    public class ReportGenerator
    {
        private readonly SalaryCalculator _salaryCalculator;

        /// <summary>
        /// Initializes a new instance of the ReportGenerator class
        /// </summary>
        /// <param name="salaryCalculator">Salary calculator instance</param>
        public ReportGenerator(SalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator ?? throw new ArgumentNullException(nameof(salaryCalculator));
        }

        /// <summary>
        /// Generates a formatted report for an employee
        /// </summary>
        /// <param name="employee">The employee to generate report for</param>
        /// <returns>Formatted employee information string</returns>
        public string GenerateEmployeeReport(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var sb = new StringBuilder();
            sb.AppendLine("=====================================");
            sb.AppendLine("       EMPLOYEE REPORT");
            sb.AppendLine("=====================================");
            sb.AppendLine($"ID: {employee.Id}");
            sb.AppendLine($"Name: {employee.Name}");
            sb.AppendLine($"Email: {employee.Email}");
            sb.AppendLine($"Monthly Salary: {employee.MonthlySalary:C}");
            sb.AppendLine($"Annual Salary: {_salaryCalculator.CalculateAnnualSalary(employee):C}");
            sb.AppendLine("=====================================");

            return sb.ToString();
        }

        /// <summary>
        /// Generates a summary report for all employees
        /// </summary>
        /// <param name="repository">Employee repository containing employees</param>
        /// <returns>Formatted summary report</returns>
        public string GenerateSummaryReport(EmployeeRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            var employees = repository.GetAll();
            if (employees.Count == 0)
                return "No employees found.";

            var sb = new StringBuilder();
            sb.AppendLine("=====================================");
            sb.AppendLine("    EMPLOYEE SUMMARY REPORT");
            sb.AppendLine("=====================================");
            sb.AppendLine($"Total Employees: {employees.Count}");

            decimal totalMonthlySalary = 0;
            foreach (var emp in employees)
            {
                totalMonthlySalary += emp.MonthlySalary;
                sb.AppendLine($"- {emp.Name} (ID: {emp.Id}): {emp.MonthlySalary:C}");
            }

            sb.AppendLine("-------------------------------------");
            sb.AppendLine($"Total Monthly Salary: {totalMonthlySalary:C}");
            sb.AppendLine($"Average Monthly Salary: {(totalMonthlySalary / employees.Count):C}");
            sb.AppendLine("=====================================");

            return sb.ToString();
        }
    }
}