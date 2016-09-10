using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AorangiPeak.Infrastructure.ADORepository
{
    /// <summary>
    /// User Profile Repository Class
    /// </summary>
    public class AdoUserProfileRepository : IUserRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        #region constructor
        public AdoUserProfileRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }
        #endregion

        #region query methods
        public IQueryable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public User FindBy(Guid key)
        {
            throw new NotImplementedException();
        }

        public User FindBy(string name)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region modify methods
        public void Add(User aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Save(User aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Remove(User aggregateRoot)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region persist methods
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
        #endregion
    }
}
