using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Infrastructure.Connection;
using AorangiPeak.Infrastructure.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Autofac;

namespace AorangiPeak.Infrastructure.Context
{
    public class AdoRepositoryContext : IAdoRepositoryContext
    {
        #region Private members
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _addedEntities;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _changedEntities;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _deletedEntities;
        private Hashtable _repositories;
        #endregion

        #region Constructor
        public AdoRepositoryContext()
        {
            _addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _changedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();

            _repositories = new Hashtable();
        }
        #endregion

        #region Public methods
        public SqlConnection CreateConnection()
        {
            return (SqlConnection)new ConnectionFactory("AorangiPeak").Create();
        }

        public void RegisterAmended(IAggregateRoot root, IUnitOfWorkRepository repository)
        {
            if (!_changedEntities.ContainsKey(root))
            {
                _changedEntities.Add(root, repository);
            }
        }

        public void RegisterNew(IAggregateRoot root, IUnitOfWorkRepository repository)
        {
            if (!_addedEntities.ContainsKey(root))
            {
                _addedEntities.Add(root, repository);
            };
        }

        public void RegisterRemoved(IAggregateRoot root, IUnitOfWorkRepository repository)
        {
            if (!_deletedEntities.ContainsKey(root))
            {
                _deletedEntities.Add(root, repository);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>() where T : class, IAggregateRoot
        {
            var typeName = typeof(T).Name;

            if (!this._repositories.ContainsKey(typeName))
            {
                object repositoryInstance = null;
                using (IContainer container = AutofacContainer.GetContainer())
                {
                    repositoryInstance = container.Resolve<IRepository<T>>(new TypedParameter(typeof(IAdoRepositoryContext), this));
                }

                if (repositoryInstance != null)
                    this._repositories.Add(typeName, repositoryInstance);
            }

            return (IRepository<T>)this._repositories[typeName];
        }

        public void SaveChanges()
        {
            using (var scope = new TransactionScope())
            {
                foreach (var root in this._addedEntities.Keys)
                {
                    this._addedEntities[root].PersistCreationOf(root);
                }

                foreach (var root in this._changedEntities.Keys)
                {
                    this._changedEntities[root].PersistUpdateOf(root);
                }

                foreach (var root in this._deletedEntities.Keys)
                {
                    this._deletedEntities[root].PersistDeletionOf(root);
                }

                scope.Complete();
            }

            ClearRegisterations();
        }
        #endregion

        #region Protected methods
        protected void ClearRegisterations()
        {
            _addedEntities.Clear();
            _changedEntities.Clear();
            _deletedEntities.Clear();
        }
        #endregion
    }
}
