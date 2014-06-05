using PTO.Entity.Renweb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping.Renweb
{
    public class RenwebGradeLevelResultMap : AuditEntityMap<RenwebGradeLevelResult, int>
    {
        public RenwebGradeLevelResultMap()
        {
            ToTable("RenwebGradeLevelResult");

            Property(x => x.Gradelevel)
                .HasColumnName("GradeLevel")
                .IsRequired();
        }
    }
}
