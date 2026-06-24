namespace Optimize_RepositoryBase.API.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
