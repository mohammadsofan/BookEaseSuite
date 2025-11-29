using BookEaseSuite.Application.Interfaces;
using BookEaseSuite.Domain.Entities;
using BookEaseSuite.Infrastructrue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Bidaya.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(AppDbContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Adding entity of type {EntityType}", typeof(T).Name);

            if (entity is null)
            {
                _logger.LogWarning("AddAsync called with null entity");
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbSet.AddAsync(entity, cancellationToken);

            _logger.LogInformation("Entity of type {EntityType} added", typeof(T).Name);
            return entity;
        }

        public async Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Adding range of {Count} entities of type {EntityType}", entities.Count, typeof(T).Name);
            await _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Deleting entity of type {EntityType} with Id {Id}", typeof(T).Name, id);

            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if (entity is null)
            {
                _logger.LogWarning("Entity with Id {Id} not found", id);
                return false;
            }

            _dbSet.Remove(entity);
            _logger.LogInformation("Entity with Id {Id} deleted", id);
            return true;
        }

        public bool DeleteRange(ICollection<T> entities)
        {
            _logger.LogInformation("Deleting range of {Count} entities of type {EntityType}", entities?.Count, typeof(T).Name);

            if (entities is null || entities.Count == 0)
            {
                _logger.LogWarning("DeleteRange called with null or empty list");
                return false;
            }

            _dbSet.RemoveRange(entities);
            return true;
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            _logger.LogInformation("Finding entity of type {EntityType} using filter", typeof(T).Name);

            if (filter is null)
            {
                _logger.LogWarning("FindAsync called with null filter");
                throw new ArgumentNullException(nameof(filter));
            }

            var entityQuery = _dbSet.AsQueryable();

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    entityQuery = entityQuery.Include(include);
                }
            }

            return await entityQuery.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            _logger.LogInformation("Getting all entities of type {EntityType}", typeof(T).Name);

            var entityQuery = _dbSet.AsQueryable();

            if (includes is not null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    entityQuery = entityQuery.Include(include);
                }
            }

            return await entityQuery.ToListAsync(cancellationToken);
        }

        public async Task<ICollection<T>> GetAllByFilter(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            _logger.LogInformation("Getting filtered list of {EntityType}", typeof(T).Name);

            if (filter is null)
            {
                _logger.LogWarning("GetAllByFilter called with null filter");
                throw new ArgumentNullException(nameof(filter));
            }

            var entityQuery = _dbSet.AsQueryable();

            if (includes != null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    entityQuery = entityQuery.Include(include);
                }
            }

            return await entityQuery.Where(filter).ToListAsync(cancellationToken);
        }

        public Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            _logger.LogInformation("Getting entity of type {EntityType} by Id {Id}", typeof(T).Name, id);

            var entityQuery = _dbSet.AsQueryable();

            if (includes != null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    entityQuery = entityQuery.Include(include);
                }
            }

            return entityQuery.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Saving changes to database for {EntityType}", typeof(T).Name);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> UpdateAsync(long id, T entity, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Updating entity of type {EntityType} with Id {Id}", typeof(T).Name, id);

            if (entity is null)
            {
                _logger.LogWarning("UpdateAsync called with null entity");
                throw new ArgumentNullException(nameof(entity));
            }

            var existingEntity = await _dbSet.FindAsync(id, cancellationToken);

            if (existingEntity == null)
            {
                _logger.LogWarning("Entity with Id {Id} not found for update", id);
                return false;
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _logger.LogInformation("Entity with Id {Id} updated", id);

            return true;
        }
    }
}
