using Microsoft.EntityFrameworkCore;
using Optimize_RepositoryBase.API.Abstractions;
using Optimize_RepositoryBase.API.Infrastructure;
using System.Linq.Expressions;

namespace Optimize_RepositoryBase.API.Repositories
{
    public class RepositoryBaseGood<TEntity, TKey> : IRepositoryBaseGood<TEntity, TKey>, IDisposable where TEntity : DomainEntity<TKey>
    {
        private readonly ApplicationDBContext _context;

        public RepositoryBaseGood(ApplicationDBContext context)
        {
            _context = context;           
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        /// <summary>
        /// haven't reached to db to fetch data so this is not case IO-bound
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> items = _context.Set<TEntity>().AsNoTracking();
            if (includeProperties != null) {
                foreach (var property in includeProperties) { 
                    items = items.Include(property);
                }
            }
            return items;
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> items = _context.Set<TEntity>().AsNoTracking();
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    items = items.Include(property);
                }
            }
            return items.Where(predicate);
        }

        public async Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await FindAll(includeProperties)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await FindAll(includeProperties)
                .SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<TEntity>()
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            if (entity != null)
            {
                Remove(entity);
            }
        }

        public void RemoveMultiple(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
