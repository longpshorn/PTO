using PTO.Entity.Renweb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping.Renweb
{
    public class RenwebSchoolResultMap : AuditEntityMap<RenwebSchoolResult, int>
    {
        public RenwebSchoolResultMap()
        {
            ToTable("RenwebSchoolResult");

            Property(x => x.Staff)
                .HasColumnName("Staff");

            Property(x => x.Title)
                .HasColumnName("Title");

            Property(x => x.Website)
                .HasColumnName("Website");

            Property(x => x.Department)
                .HasColumnName("Department");

            Property(x => x.Email)
                .HasColumnName("Email");

            Property(x => x.Work)
                .HasColumnName("Work");

            Property(x => x.Other)
                .HasColumnName("Other");

            Property(x => x.Photo)
                .HasColumnName("Photo");
        }
    }
}
