namespace EasyRent.Application.Interfaces.Repositories;

/// <summary>
/// Shared data-access contract for entities with an integer primary key
/// (Apartment, Booking, Payment). Users are handled separately via Identity's UserManager.
/// </summary>
public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);

    /// <summary>Persists pending changes; returns the number of affected rows.</summary>
    Task<int> SaveChangesAsync();
}
