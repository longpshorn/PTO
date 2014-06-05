using System;
using PTO.Core.Interfaces;

namespace PTO.Core.Entities
{
    public abstract class EntityBase<TEntity, TKey> : IEquatable<TEntity>, IEntityBase<TKey>
        where TEntity : class , IEntityBase<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }

        public bool Equals(TEntity other)
        {
            if (other == null)
            {
                return false;
            }

            return ReferenceEquals(other, this) || (other.Id.Equals(Id) && !Id.Equals(default(TKey)));
        }

        public override bool Equals(object obj)
        {
            var entityBase = obj as TEntity;

            if (entityBase == null)
            {
                return false;
            }

            return ReferenceEquals(entityBase, this) || (entityBase.Id.Equals(Id) && !Id.Equals(default(TKey)));
        }

        public override int GetHashCode()
        {
            return Id.Equals(default(TKey)) ? base.GetHashCode() : Id.GetHashCode();
        }
    }
}
