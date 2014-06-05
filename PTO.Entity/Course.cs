using PTO.Core.Entities;
using PTO.Core.Enums;
using PTO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity
{
    public class Course : AuditEntity<Course, int>
    {
        public Course()
            : base()
        {
            Enrollments = new List<Enrollment>();
        }

        public string Title { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
