using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Infrastructure.UnitOfWork;
using System.Data.SqlClient;

namespace AorangiPeak.Infrastructure.Context
{
    public interface IRepositoryContext : IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot root, IUnitOfWorkRepository repository);
        void RegisterNew(IAggregateRoot root, IUnitOfWorkRepository repository);
        void RegisterRemoved(IAggregateRoot root, IUnitOfWorkRepository repository);
        IRepository<T> GetRepository<T>() where T : class, IAggregateRoot;
        SqlConnection CreateConnection();
    }
}
