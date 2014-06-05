using PTO.Entity.Renweb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping.Renweb
{
    public class RenwebFamilyResultMap : AuditEntityMap<RenwebFamilyResult, int>
    {
        public RenwebFamilyResultMap()
        {
            ToTable("RenwebFamilyResult");

            Property(x => x.Student)
                .HasColumnName("Student");

            Property(x => x.Grade)
                .HasColumnName("Grade");

            Property(x => x.Parents)
                .HasColumnName("Parents");

            Property(x => x.Home)
                .HasColumnName("Home");

            Property(x => x.Work)
                .HasColumnName("Work");

            Property(x => x.Other)
                .HasColumnName("Other");

            Property(x => x.Address)
                .HasColumnName("Address");

            Property(x => x.AddressID)
                .HasColumnName("AddressID");

            Property(x => x.personID)
                .HasColumnName("personID");

            Property(x => x.Email)
                .HasColumnName("Email");

            Property(x => x.IsProcessed)
                .HasColumnName("IsProcessed")
                .IsRequired();
        }
    }
}
