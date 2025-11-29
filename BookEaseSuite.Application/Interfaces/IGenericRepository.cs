using System.Linq.Expressions;

namespace BookEaseSuite.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(long id, T entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);
        bool DeleteRange(ICollection<T> entities);
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        Task<T?> FindAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        Task<ICollection<T>> GetAllByFilter(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
