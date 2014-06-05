using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PTO.Core.Interfaces;

namespace PTO.Infrastructure
{
    public class EntityRepository<TEntity, TContext> : EntityRepository<TEntity, int, TContext>
        where TEntity : class, IEntityBase<int>
        where TContext : DbContext, IUnitOfWork
    {
        public EntityRepository(ISession<TContext> session)
            : base(session)
        {
        }
    }

    public class EntityRepository<TEntity, TKey, TContext> : IEntityRepository<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
        where TKey : struct
        where TContext : DbContext, IUnitOfWork
    {
        private readonly ISession<TContext> _session;

        public EntityRepository(ISession<TContext> session)
        {
            _session = session;
        }

        private ISession<TContext> Session
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

        protected TContext Context { get { return Session.GetUnitOfWork(); } }

        protected virtual DbSet<TEntity> DbSet { get { return Context.Set<TEntity>(); } }

        protected virtual IQueryable<TEntity> RootQueryable { get { return DbSet.OfType<TEntity>(); } }

        // TODO: Make sure that passing "this" to the repository query works as expected (e.g., by val / by ref)
        public IEntityRepositoryQuery<TEntity, TKey> Query()
        {
            return new EntityRepositoryQuery<TEntity, TKey>(this);
        }

        public bool LazyLoadingEnabled
        {
            get
            {
                return Context.Configuration.LazyLoadingEnabled;
            }
            set
            {
                Context.Configuration.LazyLoadingEnabled = value;
            }
        }

        public TEntity Find(TKey id)
        {
            return DbSet.Find(id);
        }

        public TEntity Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null
        )
        {
            return GetAll(filter, orderBy, includeProperties).SingleOrDefault();
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null
        )
        {
            IQueryable<TEntity> query = DbSet;

            if (includeProperties != null)
            {
                includeProperties.ForEach(i => query = query.Include(i));
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (page != null && pageSize != null)
            {
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);
            }

            return query.AsQueryable();
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TKey id)
        {
            Delete(Find(id));
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        #region IEnumerable, IQueryable Definitions
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return RootQueryable.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return RootQueryable.GetEnumerator();
        }

        Type IQueryable.ElementType
        {
            get { return RootQueryable.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return RootQueryable.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return RootQueryable.Provider; }
        }
        #endregion
    }
}
