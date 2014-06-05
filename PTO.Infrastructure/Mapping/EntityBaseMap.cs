using PTO.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PTO.Infrastructure.Mapping
{
    public class EntityBaseMap<TEntity, TKey> : EntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<TEntity, TKey>
        where TKey : struct
    {
        public EntityBaseMap()
        {
            // Primary key
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
