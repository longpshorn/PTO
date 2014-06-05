using PTO.Entity.Renweb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping.Renweb
{
    public class RenwebFamilyMembersResultMap : AuditEntityMap<RenwebFamilyMembersResult, int>
    {
        public RenwebFamilyMembersResultMap()
        {
            ToTable("RenwebFamilyMembersResult");

            Property(x => x.FirstName)
                .HasColumnName("FirstName");

            Property(x => x.LastName)
                .HasColumnName("LastName");

            Property(x => x.Home)
                .HasColumnName("Home");

            Property(x => x.Work)
                .HasColumnName("Work");

            Property(x => x.Other)
                .HasColumnName("Other");

            Property(x => x.Address)
                .HasColumnName("Address");

            Property(x => x.CSZ)
                .HasColumnName("CSZ");

            Property(x => x.Address2)
                .HasColumnName("Address2");

            Property(x => x.Country)
                .HasColumnName("Country");

            Property(x => x.Photo)
                .HasColumnName("Photo");

            Property(x => x.ActiveTab)
                .HasColumnName("ActiveTab");

            Property(x => x.StudentEntry)
                .HasColumnName("StudentEntry");

            Property(x => x.Email)
                .HasColumnName("Email");

            Property(x => x.PicResized)
                .HasColumnName("PicResized");

            Property(x => x.IsProcessed)
                .HasColumnName("IsProcessed")
                .IsRequired();
        }
    }
}
