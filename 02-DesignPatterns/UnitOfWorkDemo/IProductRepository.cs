using System.Collections.Generic;

namespace UnitOfWorkDemo;

/// <summary>
/// Product repository interface with product-specific operations
/// </summary>
public interface IProductRepository : IRepository<Product>
{
    /// <summary>
    /// Gets all products that are in stock (quantity > 0)
    /// </summary>
    IEnumerable<Product> GetProductsInStock();

    /// <summary>
    /// Gets products within a price range
    /// </summary>
    IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);

    /// <summary>
    /// Updates the stock quantity of a product
    /// </summary>
    void UpdateStock(int productId, int quantity);

    /// <summary>
    /// Gets products by name (partial match)
    /// </summary>
    IEnumerable<Product> GetProductsByName(string name);
}