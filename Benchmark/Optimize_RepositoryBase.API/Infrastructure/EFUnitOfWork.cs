using Optimize_RepositoryBase.API.Abstractions;

namespace Optimize_RepositoryBase.API.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;

        public EFUnitOfWork(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public void Commit()
        {
            _dbContext?.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
