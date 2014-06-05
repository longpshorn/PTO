using PTO.Core.Entities;

namespace PTO.Infrastructure.Mapping
{
    public class AuditEntityMap<TEntity, TKey> : EntityBaseMap<TEntity, TKey>
        where TEntity : AuditEntity<TEntity, TKey>
        where TKey : struct
    {
        public AuditEntityMap()
        {
            Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired();

            Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .IsRequired();

            Property(x => x.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .IsRequired();

            Property(x => x.UpdatedDate)
                .HasColumnName("UpdatedDate")
                .IsRequired();
        }
    }
}
