using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitOfWorkDemo;

/// <summary>
/// In-memory implementation of Unit of Work
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private bool _disposed;
    private readonly List<object> _changes = [];
    private readonly Dictionary<Type, object> _repositories = [];

    public IProductRepository Products =>
        GetRepository<Product, ProductRepository>();

    public IOrderRepository Orders =>
        GetRepository<Order, OrderRepository>();

    public bool HasChanges => _changes.Count > 0;

    private TRepository GetRepository<TEntity, TRepository>()
        where TEntity : class
        where TRepository : class, IRepository<TEntity>, new()
    {
        var type = typeof(TEntity);
        if (!_repositories.TryGetValue(type, out var repo))
        {
            repo = new TRepository();
            _repositories[type] = repo;
        }
        return (TRepository)repo;
    }

    public int Complete()
    {
        var count = _changes.Count;
        Console.WriteLine($"💾 Committing {count} changes to database...");
        _changes.Clear();
        Console.WriteLine($"✅ Transaction completed successfully! {count} changes saved.");
        return count;
    }

    public void Rollback()
    {
        var count = _changes.Count;
        Console.WriteLine($"↩️ Rolling back {count} changes...");
        _changes.Clear();
        Console.WriteLine("✅ Rollback completed successfully!");
    }

    public void TrackChange(object entity) => _changes.Add(entity);

    public void Dispose()
    {
        if (!_disposed)
        {
            _repositories.Clear();
            _changes.Clear();
            Console.WriteLine("🔄 Unit of Work disposed.");
            _disposed = true;
        }
    }

    // ===== Internal Repository Implementations =====

    private sealed class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = [];
        private int _nextId = 1;

        public int Count => _products.Count;

        public ProductRepository()
        {
            // Seed data with more realistic products
            var products = new[]
            {
                new Product
                {
                    Name = "MacBook Pro 16",
                    Description = "Apple MacBook Pro with M3 Pro chip",
                    Price = 2499.99m,
                    StockQuantity = 10,
                    Category = "Laptops",
                    SKU = "MBP-16-M3P"
                },
                new Product
                {
                    Name = "Dell XPS 15",
                    Description = "Dell XPS 15 with Intel Ultra 9",
                    Price = 1899.99m,
                    StockQuantity = 8,
                    Category = "Laptops",
                    SKU = "XPS-15-U9"
                },
                new Product
                {
                    Name = "Logitech MX Master 3S",
                    Description = "Wireless ergonomic mouse",
                    Price = 99.99m,
                    StockQuantity = 50,
                    Category = "Accessories",
                    SKU = "MX-3S-W"
                },
                new Product
                {
                    Name = "Keychron K2 Pro",
                    Description = "Mechanical keyboard with hot-swappable switches",
                    Price = 89.99m,
                    StockQuantity = 30,
                    Category = "Accessories",
                    SKU = "K2-PRO-RGB"
                },
                new Product
                {
                    Name = "Samsung 27\" 4K Monitor",
                    Description = "27-inch 4K UHD IPS monitor",
                    Price = 399.99m,
                    StockQuantity = 15,
                    Category = "Monitors",
                    SKU = "S27-4K-IPS"
                },
                new Product
                {
                    Name = "USB-C 7-in-1 Hub",
                    Description = "Multi-port USB-C adapter with HDMI",
                    Price = 49.99m,
                    StockQuantity = 25,
                    Category = "Accessories",
                    SKU = "UCH-7IN1"
                },
                new Product
                {
                    Name = "External SSD 1TB",
                    Description = "Portable SSD with USB-C 3.2",
                    Price = 119.99m,
                    StockQuantity = 20,
                    Category = "Storage",
                    SKU = "ESSD-1TB-C"
                }
            };

            foreach (var product in products)
            {
                Add(product);
            }
        }

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> GetAll() => _products.AsReadOnly();

        public void Add(Product entity)
        {
            var product = entity with { Id = _nextId++, CreatedDate = DateTime.UtcNow };
            _products.Add(product);
        }

        public void Update(Product entity)
        {
            var existing = GetById(entity.Id);
            if (existing is not null)
            {
                var index = _products.IndexOf(existing);
                _products[index] = entity with { CreatedDate = existing.CreatedDate };
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product is not null) _products.Remove(product);
        }

        public bool Exists(int id) => _products.Any(p => p.Id == id);

        public IEnumerable<Product> GetProductsInStock()
            => _products.Where(p => p.StockQuantity > 0);

        public IEnumerable<Product> GetProductsByPriceRange(decimal min, decimal max)
            => _products.Where(p => p.Price >= min && p.Price <= max);

        public void UpdateStock(int productId, int quantity)
        {
            var product = GetById(productId);
            if (product is not null)
            {
                var index = _products.IndexOf(product);
                _products[index] = product with { StockQuantity = Math.Max(0, quantity) };
            }
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            var searchTerm = name.ToLowerInvariant();
            return _products.Where(p =>
                p.Name.ToLowerInvariant().Contains(searchTerm) ||
                (p.Description?.ToLowerInvariant().Contains(searchTerm) ?? false)
            );
        }
    }

    private sealed class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = [];
        private int _nextId = 1;

        public int Count => _orders.Count;

        public Order? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetAll() => _orders.AsReadOnly();

        public void Add(Order entity)
        {
            var order = entity with { Id = _nextId++, OrderDate = DateTime.UtcNow };
            _orders.Add(order);
        }

        public void Update(Order entity)
        {
            var existing = GetById(entity.Id);
            if (existing is not null)
            {
                var index = _orders.IndexOf(existing);
                _orders[index] = entity with { OrderDate = existing.OrderDate };
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order is not null) _orders.Remove(order);
        }

        public bool Exists(int id) => _orders.Any(o => o.Id == id);

        public IEnumerable<Order> GetOrdersByCustomer(int customerId)
            => _orders.Where(o => o.CustomerId == customerId);

        public IEnumerable<Order> GetOrdersByStatus(string status)
            => _orders.Where(o =>
                o.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            var order = GetById(orderId);
            if (order is not null)
            {
                var index = _orders.IndexOf(order);
                _orders[index] = order with { Status = newStatus };
                Console.WriteLine($"📦 Order #{orderId} status updated to: {newStatus}");
            }
        }

        public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
            => _orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate);
    }
}