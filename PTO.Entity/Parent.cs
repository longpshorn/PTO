using PTO.Core.Enums;
using PTO.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity
{
    public class Parent : User
    {
        public Parent()
            : base()
        {
            UserType = UserType.Parent;
        }

        public virtual ICollection<Student> Children
        {
            get
            {
                return Relationships.Where(x => x.RelationType == RelationType.Child)
                    .Select(x => x.Relation)
                    .Cast<Student>()
                    .ToList();
            }
        }
    }
}
