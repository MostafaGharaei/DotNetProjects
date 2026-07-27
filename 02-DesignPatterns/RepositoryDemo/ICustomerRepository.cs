using System.Collections.Generic;

namespace RepositoryDemo;

/// <summary>
/// Customer repository interface
/// </summary>
public interface ICustomerRepository : IRepository<Customer>
{
    IEnumerable<Customer> GetActiveCustomers();
    Customer? GetByEmail(string email);
    IEnumerable<Customer> SearchCustomers(string searchTerm);
    IEnumerable<Customer> GetRecentCustomers(int days);
}