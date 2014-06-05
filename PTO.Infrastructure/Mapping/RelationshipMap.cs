using PTO.Entity;

namespace PTO.Infrastructure.Mapping
{
    public class RelationshipMap : AuditEntityMap<Relationship, int>
    {
        public RelationshipMap()
        {
            ToTable("Relationship");

            Property(x => x.SelfId)
                .IsRequired()
                .HasColumnName("SelfId");

            Property(x => x.RelationId)
                .IsRequired()
                .HasColumnName("RelationId");

            Property(x => x.RelationType)
                .IsRequired()
                .HasColumnName("RelationTypeId");

            HasRequired(x => x.Self)
                .WithMany(x => x.Relationships)
                .HasForeignKey(x => x.SelfId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Relation)
                .WithMany()
                .HasForeignKey(x => x.RelationId)
                .WillCascadeOnDelete(false);
        }
    }
}
