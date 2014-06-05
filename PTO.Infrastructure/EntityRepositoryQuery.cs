using PTO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure
{
    public class EntityRepositoryQuery<TEntity, TKey> : IEntityRepositoryQuery<TEntity, TKey>
        where TEntity : class, IEntityBase<TKey>
        where TKey : struct
    {
        private readonly IEntityRepository<TEntity, TKey> _repository;
        private readonly List<Expression<Func<TEntity, object>>> _includeProperties;

        public EntityRepositoryQuery(IEntityRepository<TEntity, TKey> repository)
        {
            _repository = repository;
            _includeProperties = new List<Expression<Func<TEntity, object>>>();
        }

        public IEntityRepositoryQuery<TEntity, TKey> Include(Expression<Func<TEntity, object>> expression)
        {
            _includeProperties.Add(expression);
            return this;
        }

        public TEntity Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null
        )
        {
            if (includeProperties != null)
                includeProperties.ForEach(x => _includeProperties.Add(x));
            return _repository.Get(filter, orderBy, _includeProperties);
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null
        )
        {
            if (includeProperties != null)
                includeProperties.ForEach(x => _includeProperties.Add(x));
            return _repository.GetAll(filter, orderBy, _includeProperties, page, pageSize);
        }
    }
}
