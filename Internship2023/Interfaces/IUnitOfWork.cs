namespace Internship2023_backend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
