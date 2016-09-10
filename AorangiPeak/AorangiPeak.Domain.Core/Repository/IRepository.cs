using AorangiPeak.Domain.Core.Model;
using System;
using System.Linq;

namespace AorangiPeak.Domain.Core.Repository
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        #region query methods
        IQueryable<T> FindAll();
        IQueryable<T> FindAll(int startIndex, int count);
        T FindBy(Guid key);
        T FindBy(string name);
        #endregion

        #region modify methods
        void Add(T aggregateRoot);
        void Save(T aggregateRoot);
        void Remove(T aggregateRoot);
        #endregion

    }
}
