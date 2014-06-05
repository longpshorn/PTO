using PTO.Entity;
using PTO.Entity.Enums;

namespace PTO.Service
{
    public partial interface IRelationshipService
    {
        void AddRelationship(User self, User relation, RelationType relationType);
    }
}
