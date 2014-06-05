using PTO.Entity.Renweb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping.Renweb
{
    public class RenwebClassInfoResultMap : AuditEntityMap<RenwebClassInfoResult, int>
    {
        public RenwebClassInfoResultMap()
        {
            ToTable("RenwebClassInfoResult");

            Property(x => x.ClassID)
                .HasColumnName("ClassId")
                .IsRequired();

            Property(x => x.Subject)
                .HasColumnName("Subject")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
