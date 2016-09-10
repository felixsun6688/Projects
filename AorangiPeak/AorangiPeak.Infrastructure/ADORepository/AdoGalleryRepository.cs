using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AorangiPeak.Domain.Core.Model;

namespace AorangiPeak.Infrastructure.ADORepository
{
    public class AdoGalleryRepository : IGalleryRepository, IUnitOfWorkRepository
    {
        public void Add(Gallery aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Remove(Gallery aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Save(Gallery aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Gallery> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Gallery> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public Gallery FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public Gallery FindBy(Guid key)
        {
            throw new NotImplementedException();
        }

        public void PersistCreationOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdateOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }
    }
}
