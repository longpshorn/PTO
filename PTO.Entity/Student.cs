using PTO.Core.Enums;
using PTO.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity
{
    public class Student : User
    {
        public Student()
            : base()
        {
            UserType = UserType.Student;
            Enrollments = new List<Enrollment>();
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual ICollection<Parent> Parents
        {
            get
            {
                return Relationships.Where(x => x.RelationType.Equals(RelationType.Parent))
                    .Select(x => x.Relation)
                    .Cast<Parent>()
                    .ToList();
            }
        }
    }
}
