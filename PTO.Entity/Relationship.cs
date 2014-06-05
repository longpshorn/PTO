using PTO.Core.Entities;
using PTO.Entity.Enums;

namespace PTO.Entity
{
    public class Relationship : AuditEntity<Relationship, int>
    {
        public int SelfId { get; set; }

        public virtual User Self { get; set; }

        public int RelationId { get; set; }

        public virtual User Relation { get; set; }

        public RelationType RelationType { get; set; }
    }
}
