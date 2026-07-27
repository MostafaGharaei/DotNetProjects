using System.Collections.Generic;

namespace RepositoryDemo;

/// <summary>
/// Generic repository interface
/// </summary>
public interface IRepository<T> where T : class
{
    T? GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    bool Exists(int id);
    int Count { get; }
}