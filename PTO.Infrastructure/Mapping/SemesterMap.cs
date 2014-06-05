using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping
{
    public class SemesterMap : AuditEntityMap<Semester, int>
    {
        public SemesterMap()
        {
            ToTable("Semester");

            Property(x => x.Term)
                .IsRequired()
                .HasColumnName("TermId");

            Property(x => x.Year)
                .IsRequired()
                .HasColumnName("Year");
        }
    }
}
