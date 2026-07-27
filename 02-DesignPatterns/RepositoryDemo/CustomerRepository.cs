using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryDemo;

/// <summary>
/// In-memory implementation of customer repository
/// </summary>
public sealed class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = [];
    private int _nextId = 1;

    public int Count => _customers.Count;

    public CustomerRepository()
    {
        // Seed data
        var customers = new[]
        {
            new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@email.com", Phone = "123-456-7890" },
            new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@email.com", Phone = "098-765-4321" },
            new Customer { FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@email.com", Phone = "555-123-4567", IsActive = false },
            new Customer { FirstName = "Alice", LastName = "Williams", Email = "alice.w@email.com", Phone = "555-987-6543" }
        };

        foreach (var customer in customers)
        {
            Add(customer);
        }
    }

    public Customer? GetById(int id)
        => _customers.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Customer> GetAll()
        => _customers.AsReadOnly();

    public void Add(Customer entity)
    {
        var customer = entity with { Id = _nextId++, CreatedDate = DateTime.UtcNow };
        _customers.Add(customer);
        Console.WriteLine($"✅ Customer added: {customer.FullName}");
    }

    public void Update(Customer entity)
    {
        var existing = GetById(entity.Id);
        if (existing is null)
            throw new ArgumentException($"Customer with ID {entity.Id} not found");

        var index = _customers.IndexOf(existing);
        _customers[index] = entity with { CreatedDate = existing.CreatedDate };
        Console.WriteLine($"✅ Customer updated: {entity.FullName}");
    }

    public void Delete(int id)
    {
        var customer = GetById(id);
        if (customer is null)
            throw new ArgumentException($"Customer with ID {id} not found");

        _customers.Remove(customer);
        Console.WriteLine($"✅ Customer deleted: {customer.FullName}");
    }

    public bool Exists(int id)
        => _customers.Any(c => c.Id == id);

    public IEnumerable<Customer> GetActiveCustomers()
        => _customers.Where(c => c.IsActive);

    public Customer? GetByEmail(string email)
        => _customers.FirstOrDefault(c =>
            c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Customer> SearchCustomers(string searchTerm)
    {
        var term = searchTerm.ToLowerInvariant();
        return _customers.Where(c =>
            c.FirstName.ToLowerInvariant().Contains(term) ||
            c.LastName.ToLowerInvariant().Contains(term) ||
            c.Email.ToLowerInvariant().Contains(term)
        );
    }

    public IEnumerable<Customer> GetRecentCustomers(int days)
    {
        var cutoff = DateTime.UtcNow.AddDays(-days);
        return _customers.Where(c => c.CreatedDate >= cutoff);
    }
}