using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PTO.Core.Interfaces
{
    public interface IEntityRepository<TEntity, in TKey> : IQueryable<TEntity>
        where TEntity : class, IEntityBase<TKey>
        where TKey : struct
    {
        /// <summary>
        /// Programmatically enable LazyLoading during debugging / rapid proto-typing.
        /// </summary>
        bool LazyLoadingEnabled { get; set; }

        IEntityRepositoryQuery<TEntity, TKey> Query();

        TEntity Find(TKey id);

        TEntity Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null
        );

        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null
        );

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TKey id);

        void Delete(TEntity entity);
    }
}
