using System.Collections.Generic;

namespace UnitOfWorkDemo;

/// <summary>
/// Order repository interface with order-specific operations
/// </summary>
public interface IOrderRepository : IRepository<Order>
{
    /// <summary>
    /// Gets all orders for a specific customer
    /// </summary>
    IEnumerable<Order> GetOrdersByCustomer(int customerId);

    /// <summary>
    /// Gets orders by status (Pending, Processing, Shipped, Delivered, Cancelled)
    /// </summary>
    IEnumerable<Order> GetOrdersByStatus(string status);

    /// <summary>
    /// Updates the status of an order
    /// </summary>
    void UpdateOrderStatus(int orderId, string newStatus);

    /// <summary>
    /// Gets orders within a date range
    /// </summary>
    IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
}