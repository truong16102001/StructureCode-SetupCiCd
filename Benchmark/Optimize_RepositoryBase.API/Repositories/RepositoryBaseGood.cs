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
        /// Tra ve IQueryable de tiep tuc ghep query; chua thuc su cham DB cho den khi ToList/SingleOrDefault duoc goi.
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            // Luong doc toi uu: AsNoTracking tat change tracking cua EF Core.
            // Dung cho endpoint chi query vi ta khong update cac entity nay sau khi doc.
            IQueryable<TEntity> items = _context.Set<TEntity>().AsNoTracking();
            if (includeProperties != null) {
                foreach (var property in includeProperties) { 
                    // Include van load du lieu lien ket, chi khong track graph entity da load.
                    items = items.Include(property);
                }
            }
            return items;
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            // Dat AsNoTracking truoc khi ghep filter/include de query cuoi van la read-only.
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
            // Goi database dang async giup giai phong request thread trong luc SQL Server dang xu ly I/O.
            return await FindAll(includeProperties)
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            // Ban async cua lookup theo dieu kien, duoc cac endpoint "Good" su dung.
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
