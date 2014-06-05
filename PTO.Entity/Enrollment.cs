using PTO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity
{
    public class Enrollment : AuditEntity<Enrollment, int>
    {
        public Enrollment()
            : base()
        {
        }

        public virtual Semester Semester { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
