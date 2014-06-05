using PTO.Core.Entities;
using PTO.Entity.Enums;

namespace PTO.Entity
{
    public class Semester : AuditEntity<Semester, int>
    {
        public Semester()
            : base()
        {
        }

        public Term Term { get; set; }

        public int Year { get; set; }
    }
}
