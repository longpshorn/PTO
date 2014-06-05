using System;
using System.ComponentModel.DataAnnotations;
using PTO.Core.Interfaces;

namespace PTO.Core.Entities
{
    public class AuditEntity<TEntity, TKey> : EntityBase<TEntity, TKey>, IAuditEntity
        where TEntity : class, IAuditEntity, IEntityBase<TKey>
        where TKey : struct
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        [ConcurrencyCheck]
        public DateTime UpdatedDate { get; set; }
    }
}
