using PTO.Entity;
using PTO.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Service
{
    public partial class RelationshipService
    {
        public void AddRelationship(User self, User relation, RelationType relationType)
        {
            if (self == null)
                throw new NullReferenceException("User to whom relationship is being added is null.");
            if (relation == null)
                throw new NullReferenceException("User relative is null.");

            var exists = self.Relationships.Any(x => x.SelfId.Equals(self.Id) && x.RelationId.Equals(relation.Id) && x.RelationType.Equals(relationType));
            if (!exists)
                Insert(new Relationship
                {
                    SelfId = self.Id,
                    Self = self,
                    RelationId = relation.Id,
                    Relation = relation,
                    RelationType = relationType
                });
        }
    }
}
