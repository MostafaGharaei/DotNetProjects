using System;

namespace UnitOfWorkDemo;

/// <summary>
/// Unit of Work interface for managing transactions
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Product repository
    /// </summary>
    IProductRepository Products { get; }

    /// <summary>
    /// Order repository
    /// </summary>
    IOrderRepository Orders { get; }

    /// <summary>
    /// Commits all changes to the database
    /// </summary>
    int Complete();

    /// <summary>
    /// Rolls back all changes
    /// </summary>
    void Rollback();

    /// <summary>
    /// Tracks an entity for change detection
    /// </summary>
    void TrackChange(object entity);

    /// <summary>
    /// Checks if there are any pending changes
    /// </summary>
    bool HasChanges { get; }
}