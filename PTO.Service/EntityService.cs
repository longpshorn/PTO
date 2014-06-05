using PTO.Core.Interfaces;
using PTO.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PTO.Service
{
    public abstract class EntityService<TEntity> : EntityService<TEntity, int, AppContext>
        where TEntity : class, IAuditEntity, IEntityBase<int>
    {
        protected EntityService(ISession<AppContext> session, IAppService service, Func<IEntityRepository<TEntity, int>> repository)
            : base(session, service, repository)
        {
        }
    }

    public abstract class EntityService<TEntity, TKey, TContext> : IEntityService<TEntity, TKey>
        where TEntity : class, IAuditEntity, IEntityBase<TKey>
        where TKey : struct
        where TContext : IUnitOfWork
    {
        private readonly ISession<TContext> _session;
        protected readonly IAppService _service;
        private readonly Lazy<IEntityRepository<TEntity, TKey>> _repository;

        protected EntityService(ISession<TContext> session, IAppService service, Func<IEntityRepository<TEntity, TKey>> repository)
        {
            _session = session;
            _service = service;
            _repository = new Lazy<IEntityRepository<TEntity, TKey>>(repository);
        }

        protected TContext _uow
        {
            get
            {
                return Session.GetUnitOfWork();
            }
        }

        protected ISession<TContext> Session
        {
            get
            {
                if (_session == null)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            "Repository of type {0} has not been initiated for the {1} repository.",
                            typeof(TContext).ToString(),
                            typeof(TEntity).ToString()
                        )
                    );
                }
                return _session;
            }
        }

        protected IEntityRepository<TEntity, TKey> Repository
        {
            get { return _repository.Value; }
        }

        public IEntityRepositoryQuery<TEntity, TKey> Query()
        {
            return Repository.Query();
        }

        /// <summary>
        /// Programmatically enable LazyLoading during debugging / rapid proto-typing.
        /// </summary>
        public bool LazyLoadingEnabled
        {
            get
            {
                return Repository.LazyLoadingEnabled;
            }
            set
            {
                Repository.LazyLoadingEnabled = value;
            }
        }

        protected IQueryable<TEntity> Entities
        {
            get { return Repository.AsQueryable(); }
        }

        public virtual TEntity Find(TKey id)
        {
            return Repository.Find(id);
        }

        public TEntity Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null
        )
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null
        )
        {
            return Repository.GetAll(filter, orderBy, includeProperties, page, pageSize);
        }

        public virtual void Insert(TEntity entity)
        {
            Repository.Insert(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        public virtual void Delete(TKey id)
        {
            Repository.Delete(id);
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }

        #region IEnumerable, IQueryable Definitions
        public System.Collections.Generic.IEnumerator<TEntity> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        public Type ElementType
        {
            get { return Entities.ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return Entities.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return Entities.Provider; }
        }
        #endregion
    }
}
