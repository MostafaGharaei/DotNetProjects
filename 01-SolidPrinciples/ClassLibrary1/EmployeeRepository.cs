using System;
using System.Collections.Generic;
using System.Linq;

namespace AfterSRP
{
    /// <summary>
    /// Responsible for data persistence operations for employees
    /// This class follows SRP by handling only database operations
    /// </summary>
    public class EmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// Saves an employee to the database (in-memory list)
        /// </summary>
        /// <param name="employee">The employee to save</param>
        public void Save(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            // Check if employee already exists (by ID)
            var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                // Update existing
                existing.Name = employee.Name;
                existing.Email = employee.Email;
                existing.MonthlySalary = employee.MonthlySalary;
                Console.WriteLine($"Updated employee {employee.Name} in database.");
            }
            else
            {
                // Add new
                _employees.Add(employee);
                Console.WriteLine($"Saved new employee {employee.Name} to database.");
            }
        }

        /// <summary>
        /// Retrieves all employees from the database
        /// </summary>
        /// <returns>List of all employees</returns>
        public List<Employee> GetAll()
        {
            return _employees.ToList();
        }

        /// <summary>
        /// Retrieves an employee by ID
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>The employee if found, null otherwise</returns>
        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Deletes an employee from the database
        /// </summary>
        /// <param name="id">Employee ID to delete</param>
        /// <returns>True if deleted, false if not found</returns>
        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
                Console.WriteLine($"Deleted employee {employee.Name} from database.");
                return true;
            }
            return false;
        }
    }
}