using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Core.Interfaces
{
    public interface IEntityRepositoryQuery<TEntity, in TKey>
        where TEntity : class, IEntityBase<TKey>
        where TKey : struct
    {
        IEntityRepositoryQuery<TEntity, TKey> Include(Expression<Func<TEntity, object>> expression);

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
    }
}
