using AorangiPeak.Domain.Core.Model;

namespace AorangiPeak.Infrastructure.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreationOf(IAggregateRoot root);
        void PersistUpdateOf(IAggregateRoot root);
        void PersistDeletionOf(IAggregateRoot root);
    }
}
