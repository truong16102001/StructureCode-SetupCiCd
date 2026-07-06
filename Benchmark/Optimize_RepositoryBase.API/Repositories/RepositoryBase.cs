using Microsoft.EntityFrameworkCore;
using Optimize_RepositoryBase.API.Abstractions;
using Optimize_RepositoryBase.API.Infrastructure;
using System.Linq.Expressions;

namespace Optimize_RepositoryBase.API.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>, IDisposable where TEntity : DomainEntity<TKey>
    {
        private readonly ApplicationDBContext _dbContext;

        public RepositoryBase(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            // Ban baseline: EF Core mac dinh track cac entity duoc tra ve.
            // Phu hop luong update, nhung API chi doc se ton them RAM/CPU cho change tracking.
            IQueryable<TEntity> items = _dbContext.Set<TEntity>();
            if (includeProperties != null) {
                foreach (var property in includeProperties) { 
                    // Include load them du lieu lien ket nhu StudentDetails/Evaluations kem theo Student.
                    items = items.Include(property);
                }
            }
            return items;
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> items = _dbContext.Set<TEntity>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public TEntity FindById(TKey id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public TEntity FindSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Remove(TKey id)
        {
            var entity = FindById(id);
            Remove(entity);
        }

        public void RemoveMultiple(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
