using PTO.Core.Entities;

namespace PTO.Core.Interfaces
{
    public interface IEntityService<TEntity> : IEntityService<TEntity, int>
        where TEntity : class, IAuditEntity, IEntityBase<int>
    {
    }

    public interface IEntityService<TEntity, in TKey> : IEntityRepository<TEntity, TKey>
        where TEntity : class, IAuditEntity, IEntityBase<TKey>
        where TKey : struct
    {
    }
}
