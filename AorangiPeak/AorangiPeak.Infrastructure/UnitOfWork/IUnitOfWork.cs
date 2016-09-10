using System;

namespace AorangiPeak.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
